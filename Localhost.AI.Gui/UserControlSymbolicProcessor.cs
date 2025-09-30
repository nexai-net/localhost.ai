using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Localhost.AI.Gui
{
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.Corpus;
    public partial class UserControlSymbolicProcessor : UserControl
    {
        private SymbolicProcessor _symbolicProcessor;
        private SessionManager _session;
        private Config _config;
        public UserControlSymbolicProcessor(SymbolicProcessor? symbolicProcessor)
        {
            InitializeComponent();
            Config config = ConfigurationManager.GetFromFile<Config>("config.json");
            _config = config;
            _session = new SessionManager(_config);
            //ApplyDarkTheme(this);
            if (symbolicProcessor != null)
            {
                _symbolicProcessor = symbolicProcessor;
                
                
                textBoxProcessorName.Text = _symbolicProcessor.Name;
                comboBoxMode.Text = _symbolicProcessor.Mode;
                textBoxComment.Text = symbolicProcessor.Comment;

                checkBoxDialog.Checked = _symbolicProcessor.DialogLayer;
                checkBoxSearch.Checked = _symbolicProcessor.SearchLayer;
                checkBoxFeedback.Checked = _symbolicProcessor.FeedbackLayer;
                checkBoxDreamer.Checked = _symbolicProcessor.DreamerLayer;

                textBoxRegexPatterns.Text = string.Join(", ", _symbolicProcessor.Patterns);
                textBoxMust.Text = string.Join(", ", _symbolicProcessor.Must);
                textBoxMustNot.Text = string.Join(", ",_symbolicProcessor.MustNot);
                textBoxShould.Text = string.Join(", ", _symbolicProcessor.Should);
                textBoxShouldNot.Text = string.Join(", ", _symbolicProcessor.ShouldNot);

                textBoxGeneratedTags.Text = string.Join(", ", _symbolicProcessor.GeneratedTags);
                textBoxGeneratedPromptSystem.Text = _symbolicProcessor.GeneratedSystemPrompt;
                textBoxGeneratedSentence.Text = _symbolicProcessor.GeneratedSentence;

            }
            else
            {
                _symbolicProcessor = new SymbolicProcessor();
                _symbolicProcessor.Date = DateTime.Now;

            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UserControlSymbolicProcessor_Load(object sender, EventArgs e)
        {

        }
        private void ApplyDarkTheme(Control parent)
        {
            parent.BackColor = Color.FromArgb(30, 30, 30);   // dark background
            parent.ForeColor = Color.WhiteSmoke;            // light text

            foreach (Control ctrl in parent.Controls)
            {
                // recursively apply
                ApplyDarkTheme(ctrl);

                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.FromArgb(45, 45, 48);
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.Gray;
                }

                if (ctrl is TextBox tb)
                {
                    tb.BackColor = Color.FromArgb(25, 25, 25);
                    tb.ForeColor = Color.White;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }

                if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = Color.FromArgb(30, 30, 30);
                    dgv.GridColor = Color.FromArgb(64, 64, 64);

                    // Default rows
                    dgv.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                    dgv.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
                    dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;


                    // Alternate row style
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(38, 38, 38);

                    // Headers
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 20, 20);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(20, 20, 20);
                    dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

                    // Row headers
                    dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 20, 20);
                    dgv.RowHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormToProcessor()
        {
            _symbolicProcessor.Name = textBoxProcessorName.Text;
            _symbolicProcessor.Mode = comboBoxMode.Text;
            _symbolicProcessor.Comment = textBoxComment.Text;
            _symbolicProcessor.DialogLayer = checkBoxDialog.Checked;
            _symbolicProcessor.SearchLayer = checkBoxSearch.Checked;
            _symbolicProcessor.FeedbackLayer = checkBoxFeedback.Checked;
            _symbolicProcessor.DreamerLayer = checkBoxDreamer.Checked;
            _symbolicProcessor.Patterns = GetlistElements(textBoxRegexPatterns.Text);
            _symbolicProcessor.Must = GetlistElements(textBoxMust.Text);
            _symbolicProcessor.MustNot = GetlistElements(textBoxMustNot.Text);
            _symbolicProcessor.Should = GetlistElements(textBoxShould.Text);
            _symbolicProcessor.ShouldNot = GetlistElements(textBoxShouldNot.Text);
            _symbolicProcessor.GeneratedTags = GetlistElements(textBoxGeneratedTags.Text);
            _symbolicProcessor.GeneratedSystemPrompt = textBoxGeneratedPromptSystem.Text;
            _symbolicProcessor.GeneratedSentence = textBoxGeneratedSentence.Text;
            _symbolicProcessor.Date = DateTime.Now;
            _symbolicProcessor.UserName = Environment.UserName;
            _symbolicProcessor.MachineName = _config.AppName;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            FormToProcessor();
            if (_symbolicProcessor.Id == null) _symbolicProcessor.Id = Guid.NewGuid().ToString();
            _symbolicProcessor.Comment = "Symbolic processor saved for " + _symbolicProcessor.Name;
            try
            {
                _session.SymbolicProcessorSave(_symbolicProcessor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving symbolic processor: " + ex.Message);
            }
        }
        private List<string> GetlistElements(string text)
        {
            List<string> selectedOptions = new List<string>();
            string[] texts = text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string t in texts)
            {
                string trimmed = t.Trim().ToLower();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    selectedOptions.Add(trimmed);
                }
            }
            return selectedOptions;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
