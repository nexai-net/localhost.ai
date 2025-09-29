using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localhost.AI.Core.Models;

namespace Localhost.AI.Core.Helpers
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides utility methods for making REST API calls and HTTP operations.
    /// </summary>
    public static class RestHelper
    {
        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Sends a POST request to the specified URL with the provided request data.
        /// </summary>
        /// <param name="url">The target URL for the POST request.</param>
        /// <param name="request">The RequestRobot object to send in the request body.</param>
        /// <returns>A ResponseRobot object containing the response data, or null if the request fails.</returns>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
        public static async Task<ResponseRobot?> PostAsync(string url, RequestRobot request)
        {
            // Serialize the request object to JSON
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send POST request to the specified URL
            var response = await _client.PostAsync(url, content);
            
            // Ensure the response indicates success (status 200-299)
            response.EnsureSuccessStatusCode();

            // Read the response body as a string
            var responseJson = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response into a ResponseRobot object
            // Use case-insensitive property matching for flexibility
            return JsonSerializer.Deserialize<ResponseRobot>(responseJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }



}
