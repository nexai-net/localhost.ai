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
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.Corpus;
    using Localhost.AI.Core.Models.LLM;
    using Localhost.AI.Core.Helpers;

    public partial class CacheEditForm : Form
    {
        private Cache _cache;
        private SessionManager _session;
        private Config _config;
        public CacheEditForm(Cache? c)
        {
            Config config = ConfigurationManager.GetFromFile<Config>("config.json");
            _config = config;
            _session = new SessionManager(_config);
            _session.LogSave("Application started", _config.AppName, "Info");
            if (c != null) _cache = c;
            else _cache = new Cache();

            InitializeComponent();
            PopulateFormControls();

        }

        private void PopulateFormControls()
        {
            if (_cache == null) return;
            else
            {
                textBoxChatMode.Text = _cache.chatmode;
                textBoxCompletion.Text = _cache.completion;
                textBoxGeneratedSystemPrompt.Text = _cache.generatedSystemPrompt;
                textBoxGeneratedTags.Text = string.Join(", ", _cache.generatedTags ?? new List<string>());
                textBoxModelName.Text = _cache.model;
                textBoxMustNot.Text = string.Join(", ", _cache.tagsMustNot ?? new List<string>());
                textBoxParentId.Text = _cache.ParentCacheId;
                textBoxPrompt.Text = _cache.prompt;
                textBoxShould.Text = string.Join(", ", _cache.tagsShould ?? new List<string>());
                textBoxTagsMust.Text = string.Join(", ", _cache.tagsMust ?? new List<string>());
                textBoxShouldNot.Text = string.Join(", ", _cache.tagsShouldNot ?? new List<string>());
                comboBoxLanguage.SelectedItem = _cache.language ?? "fr";
                comboBoxLanguage.SelectedIndex = 0;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCacheSaved_Click(object sender, EventArgs e)
        {
            if (_cache == null) _cache = new Cache();
            _cache.prompt = textBoxPrompt.Text;
            _cache.completion = textBoxCompletion.Text;
            _cache.language = comboBoxLanguage.SelectedItem.ToString() ?? "fr";
            _cache.model = textBoxModelName.Text ?? "mistral-small3.1";
            _cache.chatmode = textBoxChatMode.Text ?? "completion";
            _cache.tagsMust = textBoxTagsMust.Text.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();
            _cache.tagsShould = textBoxShould.Text.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();
            _cache.tagsMustNot = textBoxMustNot.Text.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();
            _cache.tagsShouldNot = textBoxShouldNot.Text.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();
            _cache.ParentCacheId = textBoxParentId.Text;
            _cache.generatedSystemPrompt = textBoxGeneratedSystemPrompt.Text;
            _cache.generatedTags = textBoxGeneratedTags.Text.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();
            _cache.Date = DateTime.Now;
            _cache.UserName = Environment.UserName;
            _cache.MachineName = _config.AppName;
            _cache.Comment = "cache saved for the prompt " + _cache.prompt;
            try
            {
                string newid = _session.CacheSave(_cache);
                _cache.Id = newid;
                MessageBox.Show("Cache saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving cache: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _session.LogSave($"Error saving cache: {ex.Message}", _config.AppName, "Error");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _session.CacheDelete(_cache.Id);
                MessageBox.Show("Cache deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting cache: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _session.LogSave($"Error deleting cache: {ex.Message}", _config.AppName, "Error");
            }
        }
    }
}
