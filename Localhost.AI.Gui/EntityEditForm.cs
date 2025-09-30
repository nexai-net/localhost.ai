using Localhost.AI.Core.Framework;
using Localhost.AI.Core.Helpers;
using Localhost.AI.Core.Models;
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


namespace Localhost.AI.Gui
{
    public partial class EntityEditForm : Form
    {
        private Entity _entity;
        private SessionManager _session;
        private Config _config;

        public EntityEditForm(Entity entity)
        {
            InitializeComponent();
            Config config = ConfigurationManager.GetFromFile<Config>("config.json");
            _config = config;
            _session = new SessionManager(_config);
            _session.LogSave("Application started", "Kaonashi.Gui", "Info");
            _entity = entity;
            ApplyDarkTheme(this);
            PopulateFormCOnstrols();
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

        private void PopulateFormCOnstrols()
        {
            Entity entity = _entity;
            // This method can be used to populate dropdowns or other controls if needed.
            if (entity != null)
            {
                txtBoxEntityName.Text = entity.Name;
                textBoxOtherNames.Text = string.Join(", ", entity.AlternativeNames ?? new List<string>());
                comboBoxEntityType.Text = entity.Type;
                textBoxShortDescription.Text = entity.ShortDescription;
                textBoxFullDescription.Text = entity.LongDescription;
                textBoxRelatedEntities.Text = string.Join(", ", entity.RelatedEntities ?? new List<string>());
                trackBarJoy.Value = entity.Joy;
                trackBarFear.Value = entity.Fear;
                trackBarAnger.Value = entity.Anger;
                trackBarSadness.Value = entity.Sadness;
                trackBarDisgust.Value = entity.Disgust;
                dateTimeFrom.Value = entity.DateFrom ?? DateTime.Now;
                dateTimeTo.Value = entity.DateTo ?? DateTime.Now.AddYears(1000);
                textBoxHowTo.Text = entity.HowTo;
                textBoxWithWhat.Text = entity.WithWhat;
                textBoxWithout.Text = entity.WithoutWhat;
                textBoxWhere.Text = entity.Where;
                textBoxWhen.Text = entity.When;
                textBoxComment.Text = entity.Comment;
            }
        }

        private void EntityEditForm_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtBoxEntityName.Text))
            {
                MessageBox.Show("Entity Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxShortDescription.Text))
            {
                MessageBox.Show("Short description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(comboBoxEntityType.Text))
            {
                MessageBox.Show("Entity type is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm() == false)
            {

            }
            else
            {
                if (_entity == null) _entity = new Entity();
                _entity.Name = txtBoxEntityName.Text;
                _entity.AlternativeNames = textBoxOtherNames.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim()).ToList();
                _entity.Type = comboBoxEntityType.Text;
                _entity.ShortDescription = textBoxShortDescription.Text;
                _entity.LongDescription = textBoxFullDescription.Text;
                _entity.RelatedEntities = textBoxRelatedEntities.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim()).ToList();
                _entity.Joy = trackBarJoy.Value;
                _entity.Fear = trackBarFear.Value;
                _entity.Anger = trackBarAnger.Value;
                _entity.Sadness = trackBarSadness.Value;
                _entity.Disgust = trackBarDisgust.Value;
                _entity.DateFrom = dateTimeFrom.Value;
                _entity.DateTo = dateTimeTo.Value;
                _entity.HowTo = textBoxHowTo.Text;
                _entity.WithWhat = textBoxWithWhat.Text;
                _entity.WithoutWhat = textBoxWithout.Text;
                _entity.Where = textBoxWhere.Text;
                _entity.When = textBoxWhen.Text;
                _entity.Date = DateTime.Now;
                _entity.UserName = Environment.UserName;
                _entity.MachineName = Environment.MachineName;
                _entity.Comment = textBoxComment.Text;

                _session.EntitySave(_entity);
            }
            // Update the entity object with data from the controls


            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonDeleteEntity_Click(object sender, EventArgs e)
        {
            _session.EntityDelete(_entity.Id);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
