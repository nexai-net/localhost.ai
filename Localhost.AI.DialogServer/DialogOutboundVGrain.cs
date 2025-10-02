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
    
    using Microsoft.AspNetCore.Http;
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.LLM;

    /// <summary>
    /// Handles outbound dialog processing in the conversation pipeline.
    /// Processes completed responses and manages caching of conversation data.
    /// </summary>
    internal class DialogOutboundVGrain : VGrainBase<IDialogOutboundVGrain>, IDialogOutboundVGrain
    {
        private Config _config;
        private SessionManager _session;
        private Completion _completion;

        /// <summary>
        /// Initializes a new instance of the DialogOutboundVGrain.  
        /// </summary>
        /// <param name="logger">The logger instance for this grain.</param>
        public DialogOutboundVGrain(ILogger<IDialogOutboundVGrain> logger) : base(logger)
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

        /// <summary>
        /// Processes an outbound dialog completion, finalizes the response and saves it to cache.
        /// </summary>
        /// <param name="completionId">The unique identifier of the completion to process.</param>
        /// <param name="Context">The execution context for this operation.</param>
        /// <returns>The completion ID after processing.</returns>
        public async Task<string> DoProcess(string completionId, IExecutionContext Context)
        {
            if(ActivateMethod() == false)
            {
                return completionId;
            }


            _config = ConfigurationManager.GetFromFile<Config>("config.json");
            _session = new SessionManager(_config);
            _session.LogSave("DialogOutbound ", _config.AppName, "Info");
            _completion = _session.CompletionLoad(completionId);

            if (_completion != null)
            {
                /// implement context processing logic here
                Console.WriteLine($"DialogOutboundVGrain: Completion loaded with Id {completionId}");
                Thread.Sleep(_config.LatencyMs);

                _completion.Status ="Completed";

                _completion.actions.Add(new Action
                {
                    typeOfAction = "OutboundProcessor",
                    timeOfAction = DateTime.Now,
                    ActionBy = _config.AppName
                });
                try
                {
                    Cache c = new Cache();
                    c.completion = _completion.response.choices[0].message.content;
                    // TO DO : modifier cette partie prompt pour reprendre le message user
                    c.prompt = _completion.prompt;
                    c.language = _completion.language;
                    c.model = _completion.request.model;
                    c.Date = DateTime.Now;
                    c.MachineName = Environment.MachineName;
                    c.UserName = Environment.UserName;
                    c.Comment = "cache done for completin of " + c.prompt;


                    _session.CacheSave(c);
                    _session.LogSave($"Cache saved for completion Id {completionId}", _config.AppName, "INFO");
                }                
                
                catch (Exception ex)
                {
                    _session.LogSave($"Error saving cache for completion Id {completionId}: {ex.Message}", "DIALOGSERVER-AGENT-OUTBOUND", "Error");
                }


                _session.CompletionSave(_completion);
                _session.LogSave($"Outbound for completion Id {completionId}", _config.AppName, "Info");
            }
            else
            {
                _session.LogSave($"Completion with Id {completionId} not found", _config.AppName, "Error");
            }
            return completionId;
        }
    }
}
