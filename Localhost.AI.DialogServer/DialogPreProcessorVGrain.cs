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
    using Localhost.AI.Core.Models.Corpus;
    using Localhost.AI.Core.Models.LLM;

    internal class DialogPreProcessorVGrain : VGrainBase<IDialogPreProcessorVGrain>, IDialogPreProcessorVGrain
    {
        private Config _config;
        private SessionManager _session;
        private Completion _completion;

        public DialogPreProcessorVGrain(ILogger<IDialogPreProcessorVGrain> logger) : base(logger)
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

        public async Task<string> DoPreProcess(string completionId, IExecutionContext Context)
        {
            if(ActivateMethod() == false)
            {
                return completionId;
            }

            _config = ConfigurationManager.GetFromFile<Config>("config.json");
            _session = new SessionManager(_config);
            _session.LogSave("DialogPreProcessor ", _config.AppName, "Info");
            _completion = _session.CompletionLoad(completionId);


            if (_completion != null)
            {
                /// implement context processing logic here
                Console.WriteLine($"DialogInboundVGrain: Completion loaded with Id {completionId}");
                Thread.Sleep(_config.LatencyMs);
                #region "Example of pre-processing"

                List<Entity> entities = _session.EntitySearchByName("");
                List<EntityItem> entityItems = new List<EntityItem>();
                foreach (Entity e in entities)
                {
                    foreach(string alias in e.AlternativeNames)
                    { 
                        entityItems.Add(new EntityItem { id = e.Id, criteria = alias });
                    }

                   /* _completion.prompt = $"\nSachant que pour {e.Name} on sait que : {e.LongDescription}. \n"+_completion.prompt;*/

                }

                List<Entity> contextEntities = new List<Entity>();

                foreach(EntityItem ei in entityItems)
                {
                    if(_completion.prompt.Contains(ei.criteria, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Write("Prompt {_completion.prompt} contains criteria {ei.criteria} or not! ");
                        contextEntities.Add(_session.EntityLoad(ei.id));

                    }
                }

                foreach(Entity ce in contextEntities)
                {
                    _completion.prompt = $"\nSachant que pour {ce.Name} on sait que : {ce.LongDescription}. \n" + _completion.prompt;
                }

                foreach (Message m in _completion.request.messages)
                {
                    if (m.role == "user")
                    {
                       m.content = "Context :"+ _completion.prompt;
                    }
                }






                #endregion
                _completion.actions.Add(new Action
                {
                    typeOfAction = "PreProcessor",
                    timeOfAction = DateTime.Now,
                    ActionBy = _config.AppName
                });

                _session.CompletionSave(_completion);
                _session.LogSave($"Inbound for completion Id {completionId}", _config.AppName, "Info");
            }
            else
            {
                _session.LogSave($"Completion with Id {completionId} not found", _config.AppName, "Error");
            }
            return completionId;
        }
    }
}
