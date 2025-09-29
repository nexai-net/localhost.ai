using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Dialog.Models
{
    [GenerateSerializer]
    public class DialogState
    {
        [Id(0)]
        public int counter { get; set; }
    }
}
