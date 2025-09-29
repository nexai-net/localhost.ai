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
    }
}
