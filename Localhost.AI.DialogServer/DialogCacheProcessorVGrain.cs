using Democrite.Framework.Core;
using Democrite.Framework.Core.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Dialog
{
    
    using Localhost.AI.Core.Models.LLM;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Framework;
    internal class DialogCacheProcessorVGrain : VGrainBase<IDialogCacheProcessorVGrain>, IDialogCacheProcessorVGrain
    {
        private Config _config;
        private SessionManager _session;
        private Completion _completion;
        public DialogCacheProcessorVGrain(ILogger<IDialogCacheProcessorVGrain> logger) : base(logger)
        {

        }
        /// <summary>
        /// Method to determine if the grain should be activated.
        /// </summary>
        /// <returns>true or False</returns>
        public bool ActivateMethod()
        {
            return true;
        }
        public async Task<string> DoProcess(string completionId, IExecutionContext Context)
        {
            if(ActivateMethod() == false)
            {
                return completionId;
            }   


            _config = ConfigurationManager.GetFromFile<Config>("config.json");
            _session = new SessionManager(_config);
            _session.LogSave("Cache processor ", _config.AppName, "Info");

            _completion = _session.CompletionLoad(completionId);


            if (_completion != null)
            {
                /// implement cache processing logic here
                Console.WriteLine($"ContextProcessorVGrain: Completion loaded with Id {completionId}");
                Thread.Sleep(_config.LatencyMs);
                
                List<Cache> caches = _session.CacheEntriesSearch(_completion.prompt);
                if(caches.Count > 0)
                {
                    // for simplicity, we take the first cache entry found
                    _completion.isCached = true;
                    _completion.cachedCompletion = caches[0].completion;
                    _session.LogSave($"Cache hit for completion Id {completionId}", _config.AppName, "Info");
                }
                else
                {
                    _completion.isCached = false;
                    _completion.cachedCompletion = "";
                    _session.LogSave($"No cache found for completion Id {completionId}", _config.AppName, "Info");
                }


                


                _completion.actions.Add(new Action
                {
                    typeOfAction = "CacheProcessor",
                    timeOfAction = DateTime.Now,
                    ActionBy = _config.AppName
                });

                _session.CompletionSave(_completion);
                _session.LogSave($"Cache updated for completion Id {completionId}", _config.AppName, "Info");
            }
            else
            {
                _session.LogSave($"Completion with Id {completionId} not found", _config.AppName, "Error");
            }
            return completionId;
        }
    }
}
