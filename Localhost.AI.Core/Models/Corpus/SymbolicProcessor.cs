using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Core.Models.Corpus
{
    using Localhost.AI.Core.Models;
    public class SymbolicProcessor : EntityBase
    {
        public string Name { get; set; }
        public string Mode { get; set; } = "In";
        public bool DialogLayer { get; set; } = false;
        public bool SearchLayer { get; set; } = false;
        public bool FeedbackLayer { get; set; } = false;
        public bool DreamerLayer { get; set; } = false;
        public List<string> Patterns { get; set; } = new List<string>();

        public List<string> Must { get; set; } = new List<string>();        
        public List<string> MustNot { get; set; } = new List<string>();        
        public List<string> Should { get; set; } = new List<string>();        
        public List<string> ShouldNot { get; set; } = new List<string>();
        
        public List<string> GeneratedTags { get; set; } = new List<string>();
        public string GeneratedSystemPrompt { get; set; } = "";
        public string GeneratedSentence { get; set; } = "";



        
    }
}
