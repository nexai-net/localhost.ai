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
            ApplyDarkTheme(this);
            if (symbolicProcessor != null)
            {
                _symbolicProcessor = symbolicProcessor;
                textBoxName.Text = symbolicProcessor.Name;
                textBoxMust.Text = string.Join(", ", symbolicProcessor.Must);
                textBoxMustNot.Text = string.Join(", ", symbolicProcessor.MustNot);
                textBoxShould.Text = string.Join(", ", symbolicProcessor.Should);
                textBoxShouldNot.Text = string.Join(", ", symbolicProcessor.ShouldNot);
                textBoxReflex.Text = string.Join(", ", symbolicProcessor.Reflex);
                textBoxThinking.Text = string.Join(", ", symbolicProcessor.Thinking);
                textBoxQuestions.Text = string.Join(", ", symbolicProcessor.Questions);
                textBoxExpectations.Text = string.Join(", ", symbolicProcessor.Expectations);
                checkBoxDialog.Checked = symbolicProcessor.DialogLayer;
                checkBoxSearch.Checked = symbolicProcessor.SearchLayer;
                checkBoxFeedback.Checked = symbolicProcessor.FeedbackLayer;
                checkBoxDreamer.Checked = symbolicProcessor.DreamerLayer;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            #region "check the form"
            _symbolicProcessor.Name = textBoxName.Text.Trim();
            _symbolicProcessor.Must = GetlistElements(textBoxMust.Text);
            _symbolicProcessor.MustKeySearcgh = textBoxMust.Text.ToLower();
            _symbolicProcessor.MustNot = GetlistElements(textBoxMustNot.Text);
            _symbolicProcessor.MustNotKeySearch = textBoxMustNot.Text.ToLower();
            _symbolicProcessor.Should = GetlistElements(textBoxShould.Text);
            _symbolicProcessor.ShouldKeySearch = textBoxShould.Text.ToLower();
            _symbolicProcessor.ShouldNot = GetlistElements(textBoxShouldNot.Text);
            _symbolicProcessor.ShouldNotKeySearch = textBoxShouldNot.Text.ToLower();
            _symbolicProcessor.Reflex = GetlistElements(textBoxReflex.Text);
            _symbolicProcessor.ReflexKeySearch = textBoxReflex.Text.ToLower();
            _symbolicProcessor.Thinking = GetlistElements(textBoxThinking.Text);
            _symbolicProcessor.ThinkingKeySearch = textBoxThinking.Text.ToLower();
            _symbolicProcessor.Questions = GetlistElements(textBoxQuestions.Text);
            _symbolicProcessor.QuestionsKeySearch = textBoxQuestions.Text.ToLower();
            _symbolicProcessor.Expectations = GetlistElements(textBoxExpectations.Text);
            _symbolicProcessor.ExpectationsKeySearch = textBoxExpectations.Text.ToLower();
            _symbolicProcessor.DialogLayer = checkBoxDialog.Checked;
            _symbolicProcessor.SearchLayer = checkBoxSearch.Checked;
            _symbolicProcessor.FeedbackLayer = checkBoxFeedback.Checked;
            _symbolicProcessor.DreamerLayer = checkBoxDreamer.Checked;
            //+ _symbolicProcessor.Reflex.Count + _symbolicProcessor.Thinking.Count + _symbolicProcessor.Questions.Count + _symbolicProcessor.Expectations.Count 

            if (_symbolicProcessor.Must.Count + _symbolicProcessor.MustNot.Count + _symbolicProcessor.Should.Count + _symbolicProcessor.ShouldNot.Count > 1 && _symbolicProcessor.Reflex.Count + _symbolicProcessor.Thinking.Count + _symbolicProcessor.Questions.Count + _symbolicProcessor.Expectations.Count > 1)
            {
                string newid = _session.SymbolicProcessorSave(_symbolicProcessor);
                label1.Text = $"Symbolic Processor '{_symbolicProcessor.Name}' saved with ID: {newid}";
                _symbolicProcessor.Id = newid;
            }
            else
            {
                MessageBox.Show("At least one of the lists must contain elements.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            #endregion
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
    }
}
