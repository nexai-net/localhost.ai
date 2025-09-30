namespace Localhost.AI.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Localhost.AI.Core.Models.LLM;

    /// <summary>
    /// Provides methods for communicating with Ollama language model API endpoints.
    /// </summary>
    public static class OllamaManager
    {
        private static readonly HttpClient httpClient = new HttpClient();

        

        /// <summary>
        /// Sends a request to the Ollama API and returns the response.
        /// </summary>
        /// <param name="url">The Ollama API endpoint URL.</param>
        /// <param name="request">The request object containing the model and messages.</param>
        /// <returns>A Response object containing the completion results from Ollama.</returns>
        /// <exception cref="Exception">Thrown when the HTTP request fails or response parsing fails.</exception>
        public static async Task<Response> CallOllamaAsync(string url, Request request)
        {
            try
            {
                // Serialize the request object to JSON
                string json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send POST request to the Ollama API endpoint
                var response = await httpClient.PostAsync(url, content);
                
                // Ensure the response indicates success (status 200-299)
                response.EnsureSuccessStatusCode();

                // Read the response body as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a Response object
                // Use case-insensitive property matching for flexibility
                var result = JsonSerializer.Deserialize<Response>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Return the deserialized response or a default response if deserialization failed
                return result ?? new Response { model = "Unknown", id = "empty" };
            }
            catch (Exception ex)
            {
                // If an error occurs, return an error response with the exception message
                return new Response
                {
                    id = "error",
                    model = "exception",
                    choices = new List<Choice>
                {
                    new Choice
                    {
                        index = 0,
                        message = new Message { role = "system", content = ex.Message },
                        finish_reason = "error"
                    }
                }
                };
            }
        }
    }
}
