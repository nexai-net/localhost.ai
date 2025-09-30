using Democrite.Framework.Core.Abstractions;
using Democrite.Framework.Core.Abstractions.Attributes;
using Democrite.Framework.Core.Abstractions.Attributes.MetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Dialog
{
    
    using Localhost.AI.Core.Models.LLM;
    [VGrainCategory("PreprocessingSearch")]
    //[VGrainMetaData()]
    public interface IPreSearchVGrain : IVGrain
    {
        Task<string> DoPreProcess(string completionId, IExecutionContext Context);

    }
}
