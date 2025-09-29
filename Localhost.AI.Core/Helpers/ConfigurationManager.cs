namespace Localhost.AI.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Provides utility methods for managing configuration files and settings.
    /// </summary>
    public static class ConfigurationManager
    {
        /// <summary>
        /// Deserializes a JSON configuration file into a strongly-typed object.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize to. Must have a parameterless constructor.</typeparam>
        /// <param name="fullName">The full path to the JSON configuration file.</param>
        /// <returns>The deserialized object of type T, or a new instance if deserialization fails.</returns>
        /// <exception cref="Exception">Thrown when file reading or JSON deserialization fails.</exception>
        public static T? GetFromFile<T>(string fullName) where T : new()
        {
            try
            {
                // Read the entire JSON file content as a string
                string json = File.ReadAllText(fullName);
                
                // Deserialize the JSON string into the specified type T
                // If deserialization returns null, create a new instance of T
                return JsonSerializer.Deserialize<T>(json) ?? new T();
            }
            catch (Exception ex)
            {
                // Re-throw any exceptions that occur during file reading or deserialization
                throw;
            }
        }
    }
}
