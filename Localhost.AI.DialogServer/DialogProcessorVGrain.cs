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

    /// <summary>
    /// Handles the main dialog processing logic in the conversation pipeline.
    /// Manages language model interactions and response generation.
    /// </summary>
    internal class DialogProcessorVGrain : VGrainBase<IDialogProcessorVGrain>, IDialogProcessorVGrain
    {
        private Config _config;
        private SessionManager _session;
        private Completion _completion;

        /// <summary>
        /// Initializes a new instance of the DialogProcessorVGrain.
        /// </summary>
        /// <param name="logger">The logger instance for this grain.</param>
        public DialogProcessorVGrain(ILogger<IDialogProcessorVGrain> logger) : base(logger)
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
        /// Processes a dialog completion by either retrieving cached responses or calling the language model.
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
            
            // Log the start of dialog processing
            _session.LogSave("DialogProcessor ", "DIALOGSERVER_AGENT_PROCESSOR", "Info");
            
            // Load the completion object from the repository
            _completion = _session.CompletionLoad(completionId);

            // Check if the completion was successfully loaded
            if (_completion != null)
            {
                // Log that the completion was loaded successfully
                Console.WriteLine($"DialogInboundVGrain: Completion loaded with Id {completionId}");
                
                // Add a small delay as configured
                Thread.Sleep(_config.LatencyMs);

                // Add an action to track the main processing step
                _completion.actions.Add(new Action
                {
                    typeOfAction = "MainProcessor",
                    timeOfAction = DateTime.Now,
                    ActionBy = _config.AppName
                });
                
                // Check if we have a cached response for this completion
                if (_completion.isCached)
                {
                    // Create a choice object with the cached completion
                    Choice choice = new Choice
                    {
                        index = 0,
                        message = new Message
                        {
                            role = "assistant",
                            content = _completion.cachedCompletion
                        },
                        finish_reason = "stop"
                    };
                    
                    // Set up the response with the cached choice
                    _completion.response.choices = new List<Choice>();
                    _completion.response.choices.Add(choice);
                }
                else
                {
                    // Call the Ollama API to get a fresh response
                    Response r = await OllamaManager.CallOllamaAsync(_config.OllamaUrl, _completion.request);
                    _completion.response = r;
                }
                
                // Save the updated completion back to the repository
                _session.CompletionSave(_completion);
                
                // Log successful completion of processing
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
