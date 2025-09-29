namespace Localhost.AI.Admin
{
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models.LLM;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Models.Corpus;

    /// <summary>
    /// Main entry point for the Localhost.AI Admin application.
    /// Provides administrative functionality for managing the AI system.
    /// </summary>
    internal class Program
    {
        static private SessionManager _session;
        static private Config _config;
        
        /// <summary>
        /// Main entry point for the Admin application.
        /// Initializes the system and performs administrative operations.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            // Load configuration from file
            Config config = ConfigurationManager.GetFromFile<Config>("config.json");
            
            // Display application startup information
            Console.WriteLine($"Starting {config.AppName} - {config.AppDescription}");
            Console.WriteLine($"Documentation: {config.AppDocumentationUrl}");

            // Set up application name with fallback
            string AppName = config.AppName ?? "APPx";
            _config = config;
            
            // Initialize session manager with the configuration
            _session = new SessionManager(_config);
            
            // Log that the application has started
            _session.LogSave("Application started", AppName, "Info");
            
            // Search for entities by name as a demonstration
            List<Entity> entities = _session.EntitySearchByName("qui est Jerome Fortias ?");
            
            // Display found entities
            foreach(Entity e in entities)
            {
                Console.WriteLine($"Entity: {e.Name} - {e.Id}");
            }
        }
    }
}
