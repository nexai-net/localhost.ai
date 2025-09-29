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

    /// <summary>
    /// Handles inbound dialog processing in the conversation pipeline.
    /// Processes incoming user messages and prepares them for further processing.
    /// </summary>
    internal class DialogInboundVGrain : VGrainBase<IDialogInboundVGrain>, IDialogInboundVGrain
    {
        
        private Config _config;
        private SessionManager _session;    
        private Completion _completion;
        
        /// <summary>
        /// Initializes a new instance of the DialogInboundVGrain.
        /// </summary>
        /// <param name="logger">The logger instance for this grain.</param>
        public DialogInboundVGrain(ILogger<IDialogInboundVGrain> logger) : base(logger)
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
        /// Processes an inbound dialog completion, extracting user messages and preparing them for further processing.
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
            // Load configuration from file
            _config = ConfigurationManager.GetFromFile<Config>("config.json");
            
            // Initialize session manager with the configuration
            _session = new SessionManager(_config);
            
            // Log the start of inbound processing
            _session.LogSave("Dialog Inbound...", "DIALOGSERVER-AGENT-INBOUND", "Info");
            
            // Load the completion object from the repository
            _completion = _session.CompletionLoad(completionId);

            // Check if the completion was successfully loaded
            if (_completion != null)
            {
                // Log that the completion was loaded successfully
                Console.WriteLine($"DialogInboundVGrain: Completion loaded with Id {completionId}");
                
                // Add a small delay as configured
                Thread.Sleep(_config.LatencyMs);
                
                #region "Example of inbound processing"
                
                // Set the completion status to running
                _completion.Status = "running";

                // Extract all user messages from the request
                List<Message> messages = new List<Message>();
                messages = _completion.request.messages.Where(m => m.role == "user").ToList();

                // Concatenate all user messages into a single prompt
                foreach (Message m in messages)
                {
                 _completion.prompt += m.content + "\n";
                }

                // Log the number of user messages found
                Console.WriteLine(messages.Count);

                #endregion

                // Add an action to track the inbound processing step
                _completion.actions.Add(new Action
                {
                    typeOfAction = "InboundProcessor",
                    timeOfAction = DateTime.Now,
                    ActionBy = _config.AppName
                });

                // Save the updated completion back to the repository
                _session.CompletionSave(_completion);
                
                // Log successful completion of inbound processing
                _session.LogSave($"Inbound for completion Id {completionId}", "DIALOGSERVER-AGENT-INBOUND", "Info");
            }
            else
            {
                // Log error if completion was not found
                _session.LogSave($"Completion with Id {completionId} not found", "DIALOGSERVER-AGENT-CONTEXTUPDATE", "Error");
            }
            
            // Return the completion ID for the next step in the pipeline
            return completionId;
        }
    }
}
