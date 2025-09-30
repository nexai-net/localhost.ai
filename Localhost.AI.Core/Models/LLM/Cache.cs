using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Core.Models.LLM
{
    public class Cache : EntityBase
    {
        public string prompt { get; set; } = "";
        public string completion { get; set; } = "";
        public string language { get; set; } = "fr";
        public string model { get; set; } = "mistral-small3.1";
        public string chatmode { get; set; } = "completion"; // chat or completion or diagnostic    
        public List<string> tagsMust { get; set; } = new List<string>();
        public List<string> tagsShould { get; set; } = new List<string>();
        public List<string> tagsMustNot { get; set; } = new List<string>();
        public List<string> tagsShouldNot { get; set; } = new List<string>();
        public string ParentCacheId { get; set; } = "";
        public List<string> generatedTags { get; set; } = new List<string>();
        public string generatedSystemPrompt { get; set; } = ""; 

    }



}
