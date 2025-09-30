using Democrite.Framework.Core;
using Democrite.Framework.Core.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.Dialog
{
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.Corpus;
    using Localhost.AI.Core.Models.LLM;

    internal class PreSearchVGrain : VGrainBase<IPreSearchVGrain>, IPreSearchVGrain
    {
        private Config _config;
        private SessionManager _session;
        private Completion _completion;

        public PreSearchVGrain(ILogger<IPreSearchVGrain> logger) : base(logger)
        {

        }
        /// <summary>
        /// Method to determine if the grain should be activated.
        /// </summary>
        /// <returns>true or False</returns>
        public bool ActivateMethod()
        {
            return true;
        }

        public async Task<string> DoPreProcess(string researchId, IExecutionContext Context)
        {
            if(ActivateMethod() == false)
            {
                return researchId;
            }
            _config = ConfigurationManager.GetFromFile<Config>("config.json");
            _session = new SessionManager(_config);
            _session.LogSave("SearchPreProcessor ", _config.AppName, "Info");
            return researchId;
        }
    }
}
