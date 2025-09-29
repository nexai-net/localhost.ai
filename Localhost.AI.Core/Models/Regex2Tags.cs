using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Core.Models
{
    public class Regex2Tags : EntityBase
    {
        public string pattern { get; set; } = "";
        public string promptsystem { get; set; } = "";
        public List<string> tagsMust { get; set; } = new List<string>();
        public List<string> tagsShould { get; set; } = new List<string>();
        public List<string> tagsMustNot { get; set; } = new List<string>();
        public List<string> tagsShouldNot { get; set; } = new List<string>();

    }
}
