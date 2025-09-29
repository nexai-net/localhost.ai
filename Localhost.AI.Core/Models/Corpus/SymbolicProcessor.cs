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
        public List<string> Must { get; set; } = new List<string>();
        public string MustKeySearcgh { get; set; } = string.Empty;
        public List<string> MustNot { get; set; } = new List<string>();
        public string MustNotKeySearch { get; set; } = string.Empty;
        public List<string> Should { get; set; } = new List<string>();
        public string ShouldKeySearch { get; set; } = string.Empty;
        public List<string> ShouldNot { get; set; } = new List<string>();
        public string ShouldNotKeySearch { get; set; } = string.Empty;
        public List<string> Reflex { get; set; } = new List<string>();
        public string ReflexKeySearch { get; set; } = string.Empty;
        public List<string> Thinking { get; set; } = new List<string>();
        public string ThinkingKeySearch { get; set; } = string.Empty;
        public List<string> Questions { get; set; } = new List<string>();
        public string QuestionsKeySearch { get; set; } = string.Empty;
        public List<string> Expectations { get; set; } = new List<string>();
        public string ExpectationsKeySearch { get; set; } = string.Empty;
        public bool DialogLayer { get; set; } = false;
        public bool SearchLayer { get; set; } = false;
        public bool FeedbackLayer { get; set; } = false;
        public bool DreamerLayer { get; set; } = false;
    }
}
