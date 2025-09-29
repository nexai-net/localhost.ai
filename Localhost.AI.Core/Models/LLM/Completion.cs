using Elasticsearch.Net;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Localhost.AI.Core.Models.LLM
{

    
    public class Completion : EntityBase
    {
        public Request? request { get; set; }
        public Response? response { get; set; }
        public string prompt { get; set; } = "";
        public string sessionId { get; set; } = "localhost";
        public List<Action> actions { get; set; } = new List<Action>();
        public string Status { get; set; } = "initialized";
        public string language { get; set; } = "fr";
        public bool isCached { get; set; } = false;
        public string cachedCompletion { get; set; } = "";

    }

    public class Action
    { 
        public string typeOfAction { get; set; } = "";
        public DateTime timeOfAction { get; set; } = DateTime.Now;
        public string ActionBy { get; set; } = "system";

    }
}
