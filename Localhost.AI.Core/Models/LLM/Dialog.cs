using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Core.Models.LLM
{
    using Localhost.AI.Core.Models;
/// <summary>
/// 
/// </summary>
    public class Dialog
    {
        public string? sessionId { get; set; }
        public Request? request { get; set; }
        public Response? response { get; set; }
        public List<MetaData>? metaDatas { get; set; }
        public bool? cached { get; set; } = false;        
        public string? previousQuestion { get; set; }
        public string? previousAnswer { get; set; }
    }
}
