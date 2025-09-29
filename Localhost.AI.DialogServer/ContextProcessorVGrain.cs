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
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Helpers;
    using OpenTelemetry.Resources;

    internal class ContextProcessorVGrain : VGrainBase<IContextProcessorVGrain>, IContextProcessorVGrain
    {
        private Config _config;
        private SessionManager _session;
        private Completion _completion;


        public bool ActivateMethod()
        {
            return true;
        }
        /// <summary>
        /// Method to determine if the grain should be activated.
        /// </summary>
        /// <returns>true or False</returns>
        public ContextProcessorVGrain(ILogger<IContextProcessorVGrain> logger) : base(logger)
        {

        }

        public async Task<string> DoProcess(string completionId, IExecutionContext Context)
        {
            if (ActivateMethod()==false)
            {
                return completionId;
            }


            _config = ConfigurationManager.GetFromFile<Config>("config.json");
            _session = new SessionManager(_config);
            
            _session.LogSave("DoProcess", _config.AppName, "INFO");
            _completion = _session.CompletionLoad(completionId);

            
            if (_completion != null)
            {
                /// implement context processing logic here
                Console.WriteLine("");
                Thread.Sleep(_config.LatencyMs);






                _completion.actions.Add(new Action
                {
                    typeOfAction = "ContextProcessor",
                    timeOfAction = DateTime.Now,
                    ActionBy = _config.AppName
                });

                _session.CompletionSave(_completion);
                _session.LogSave("", _config.AppName, "INFO");
            }
            else
            {
                _session.LogSave($"Completion with Id {completionId} not found", _config.AppName, "ERROR");
            }
            return completionId;
        }
    }
}
