namespace Localhost.AI.Gui
{
    using Localhost.AI.Core.Models.Corpus;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.LLM;
    using Localhost.AI.Core.Models.Corpus;
    public partial class SymbolicProcessorEditForm : Form
    {
        private SessionManager _session;
        private Config _config;
        private UserControlSymbolicProcessor _userControlSymbolicProcessor;
        public SymbolicProcessorEditForm(SymbolicProcessor symbolicProcessor)
        {
            InitializeComponent();
            _userControlSymbolicProcessor = new UserControlSymbolicProcessor(symbolicProcessor) { Dock = DockStyle.Fill };
            ShowControl(_userControlSymbolicProcessor);
        }


        private void ShowControl(UserControl control)
        {
            panel1.SuspendLayout();
            panel1.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel1.Controls.Add(control);
            panel1.ResumeLayout();
        }
    }
}
