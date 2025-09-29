using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Core.Helpers
{
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.LLM;
    
    /// <summary>
    /// Provides utility methods for managing language model operations and completions.
    /// </summary>
    public static class LanguageModelManager
    {
        /// <summary>
        /// Initializes a new completion object with default settings and a basic conversation structure.
        /// </summary>
        /// <returns>A new Completion object with initialized request and response structures.</returns>
        public static Completion InitializeCompletion()
        {
            // Create a new completion object
            Completion c = new Completion();
            
            // Create a user message with a simple greeting
            Message muser = new Message();
            muser.role = "user";
            muser.content = "Hi";
            
            // Create a system message to set the assistant's behavior
            Message msystsem = new Message();
            msystsem.role = "system";
            msystsem.content = "You are a helpful assistant.";

            // Create a request object for the language model
            Request req = new Request();
            req.model = "mistral-small3.1";
            req.messages = new List<Message>();
            
            // Add system message first, then user message
            req.messages.Add(msystsem);
            req.messages.Add(muser);
            req.stream = false;

            // Set up the completion object with unique identifiers
            c.Id = Guid.NewGuid().ToString();
            c.sessionId = "jerome";
            c.request = req;
            
            // Initialize the response object
            c.response = new Response();
            c.response.id = "";
            c.response.@object = "chat.completion";
            c.response.model = "mistral-small3.1";
            c.response.created = 0;
            c.response.system_fingerprint = "fp_ollama";
            
            // Set environment information
            c.UserName = Environment.UserName;
            c.MachineName = Environment.MachineName;
            c.Comment = "initialized completion";
            c.Date = DateTime.Now;
            
            // Add an initialization action to track the completion lifecycle
            c.actions.Add(new Action
            {
                typeOfAction = "initialize",
                timeOfAction = DateTime.Now,
                ActionBy = "system"
            });

            /*

            c.Response.choices = new List<Choice>();
            c.Response.choices.Add(new Choice
            {
                index = 0,
                Message = new Message { role = "assistant", content = "empty" },
                finish_reason = "stop"
            });
            c.Response.Usage = new Usage
            {
                prompt_tokens = 0,
                completion_tokens = 0,
                total_tokens = 0
            };*/


            return c;
        }
    }
}
