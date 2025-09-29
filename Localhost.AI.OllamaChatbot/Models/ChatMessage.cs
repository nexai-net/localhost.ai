using System;

namespace Localhost.AI.LlmClient.Models
{
    public class ChatMessage
    {
        public string Content { get; set; }
        public string Sender { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsUser { get; set; }
        public bool IsError { get; set; }

        public ChatMessage(string content, string sender, bool isUser = true, bool isError = false)
        {
            Content = content;
            Sender = sender;
            Timestamp = DateTime.Now;
            IsUser = isUser;
            IsError = isError;
        }
    }
}

