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
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.LLM;
    
    internal class EmotionnalOutboundVGrain : VGrainBase<IEmotionnalOutboundVGrain>, IEmotionnalOutboundVGrain
    {
        private Config _config;
        private SessionManager _session;
        private Completion _completion;

        public EmotionnalOutboundVGrain(ILogger<IEmotionnalOutboundVGrain> logger) : base(logger)
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

            if (ActivateMethod() == false)
            {
                return completionId;
            }

            _config = ConfigurationManager.GetFromFile<Config>("config.json");
            _session = new SessionManager(_config);
            _session.LogSave("EmotionnalInboundProcessor", "DIALOGSERVER_AGENT_PROCESSOR", "Info");
            _completion = _session.CompletionLoad(completionId);

            if (_completion != null)
            {
                /// implement context processing logic here
                Console.WriteLine($"DialogInboundVGrain: Completion loaded with Id {completionId}");
                Thread.Sleep(_config.LatencyMs);

                _completion.actions.Add(new Action
                {
                    typeOfAction = "EmotionnalOutboundProcessor",
                    timeOfAction = DateTime.Now,
                    ActionBy = _config.AppName
                });

                _session.CompletionSave(_completion);
                _session.LogSave($"Inbound for completion Id {completionId}", "DIALOGSERVER-AGENT-INBOUND", "Info");
            }
            else
            {
                _session.LogSave($"Completion with Id {completionId} not found", "DIALOGSERVER-AGENT-CONTEXTUPDATE", "Error");
            }
            return completionId;
        }
    }
}
