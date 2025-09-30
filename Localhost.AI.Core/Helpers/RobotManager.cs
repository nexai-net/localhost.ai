

namespace Localhost.AI.Core.Helpers
{
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.LLM;
    using Nest;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public static class RobotManager
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<Response> Say(string message, string url)
        {
            Response r = new Response();
            try
            {
                RequestRobot robot = new RequestRobot();
                robot.action = "voice";
                robot.text = message;
                robot.parameters = url;
                robot.language = "fr";

                string json = JsonSerializer.Serialize(robot);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Response>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Return the deserialized response or a default response if deserialization failed
                return result ?? new Response { model = "Unknown", id = "empty" };

            }
            catch (Exception ex) 
            {
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
