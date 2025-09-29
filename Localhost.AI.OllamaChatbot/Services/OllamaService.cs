namespace Localhost.AI.LlmClient.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Localhost.AI.Core.Models.LLM;

    public class OllamaService
    {
        private readonly HttpClient _httpClient;
        private string _baseUrl;

        public OllamaService()
        {
            _httpClient = new HttpClient();
            _baseUrl = "http://localhost:11434"; // Default Ollama URL
        }

        public void SetBaseUrl(string url)
        {
            _baseUrl = url.TrimEnd('/');
        }

        public async Task<bool> TestConnectionAsync()
        {
            return true;
         
        }

        public async Task<List<string>> GetAvailableModelsAsync()
        {
            List<string> strings = new List<string>();
            strings.Add("mistral-small3.1");
            return strings;
        }

        public async Task<string> SendMessageAsync(string message, string model = "llama2")
        {
            try
            {
                Request request = new Request
                {
                    model = "msitral-small3.1",
                    messages = new List<Message>
                    {
                        new Message
                        {
                            role = "user",
                            content = message
                        },
                        new Message
                        {
                            role = "system",
                            content = "be long"
                        },

                    },
                    stream = false
                };

               

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_baseUrl}/v1/chat/completions", content); ///v1/chat/completions

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response>(responseContent);
                    if (result == null || result.choices.Count == 0)
                    {
                     
                        return "Error: No response from model.";
                    }
                    else
                    {
                        result.choices[0].message.content = result.choices[0].message.content.Replace("\n", " ").Replace("\r", " ").Trim();
                        return result.choices[0].message.content;
                    }
                }
                else
                {
                    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }

    public class ModelsResponse
    {
        public List<ModelInfo> Models { get; set; } = new();
    }

    public class ModelInfo
    {
        public string Name { get; set; } = string.Empty;
        public string ModifiedAt { get; set; } = string.Empty;
        public long Size { get; set; }
    }

    public class GenerateResponse
    {
        public string Model { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
        public bool Done { get; set; }
    }
}
