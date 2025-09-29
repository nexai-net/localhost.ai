using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Core.Models.LLM
{
    public class Response
    {
        public string? id { get; set; }
        public string? @object { get; set; } = "chat.completion";
        public int? created { get; set; } 
        public string? model { get; set; } = string.Empty;
        public string? system_fingerprint { get; set; }
        public List<Choice>? choices { get; set; } = new List<Choice>();
        public Usage? usage { get; set; } = new Usage();
        
    }
}
