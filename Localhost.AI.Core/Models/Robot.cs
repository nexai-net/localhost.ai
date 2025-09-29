using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Core.Models
{
    public class RequestRobot
    {
        public string action { get; set; }
        public string text { get; set; }
        public string parameters { get; set; }
        public string language { get; set; }
    }

    public class ResponseRobot
    {
        public bool result { get; set; }
        
    }
}
