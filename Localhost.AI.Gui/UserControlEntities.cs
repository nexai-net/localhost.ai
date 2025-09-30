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
    public partial class UserControlEntities : UserControl
    {
        private SessionManager _session;
        private Config _config;
        private List<Entity> _entities = new List<Entity>();

        public UserControlEntities()
        {
            InitializeComponent();
            Config config = ConfigurationManager.GetFromFile<Config>("config.json");
            _config = config;
            _session = new SessionManager(_config);
            //ApplyDarkTheme(this);

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


        private void UserControlEntities_Load(object sender, EventArgs e)
        {
            LoadData(null);
        }

        private void LoadData(string searchTerm )
        {
          
            try
            {
                _entities = _session.EntitySearchByName(searchTerm);
                dataGrid.DataSource = _entities;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error loading entities: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _session.LogSave($"Error loading entities: {ex.Message}", "Kaonashi.Gui", "Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var editForm = new EntityEditForm(null);
            editForm.Show();
        }

        private void EntitiesSearchButton_Click(object sender, EventArgs e)
        {
            LoadData(searchTextBox.Text);
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
         
         
                var selectedEntity = dataGrid.Rows[e.RowIndex].DataBoundItem as Entity;
                if (selectedEntity != null)
                {
                    var editForm = new EntityEditForm(selectedEntity);
                    editForm.Show();
                }
         
        }
    }
}
