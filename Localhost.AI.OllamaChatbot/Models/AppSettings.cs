using System;

namespace Localhost.AI.LlmClient.Models
{
    public class AppSettings
    {
        public string OllamaUrl { get; set; } = "http://localhost:11434";
        public string DefaultModel { get; set; } = "llama2";
        public string UserName { get; set; } = "You";
        public string BotName { get; set; } = "Assistant";
        public bool AutoScroll { get; set; } = true;
        public bool ShowTimestamps { get; set; } = true;
    }
}

