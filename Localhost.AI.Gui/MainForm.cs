

namespace Localhost.AI.Gui
{

    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Models.LLM;
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

    /// <summary>
    /// Main form for the Localhost.AI GUI application.
    /// Provides the primary interface for interacting with the AI system and managing entities.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly UserControlHelp _helpControl;
        private readonly UserControlEntities _EntitiesControl;
        private readonly UserControlSymbolicProcessor _symbolicProcessor;
        private readonly UserControlSymbolicProcessorSearch _symbolicProcessorSearch;
        private SessionManager _session;
        private Config _config;

        /// <summary>
        /// Initializes a new instance of the MainForm.
        /// Sets up the user interface controls and initializes the application session.
        /// </summary>
        public MainForm()
        {
            // Initialize the form components
            InitializeComponent();
            
            // Apply dark theme to the form and all child controls
            ApplyDarkTheme(this);
            
            // Initialize user controls for different sections
            _helpControl = new UserControlHelp { Dock = DockStyle.Fill };
            _EntitiesControl = new UserControlEntities { Dock = DockStyle.Fill };
            _symbolicProcessor = new UserControlSymbolicProcessor(null) { Dock = DockStyle.Fill };
            _symbolicProcessorSearch = new UserControlSymbolicProcessorSearch { Dock = DockStyle.Fill };

            // Load configuration from file
            Config config = ConfigurationManager.GetFromFile<Config>("config.json");
            _config = config;
            
            // Initialize session manager with the configuration
            _session = new SessionManager(_config);
            
            // Log that the application has started
            _session.LogSave("Application started", "Kaonashi.Gui", "Info");
        }

        private void hideSansVisageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(_symbolicProcessorSearch);
        }

        private void viewSansVisageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(_EntitiesControl);
        }

        private void butAsk_Click(object sender, EventArgs e)
        {
            ActionLauncherAsync();
        }

        /// <summary>
        /// Processes user input and launches appropriate actions based on the command.
        /// Handles help commands, entity management, and AI interactions.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        private async Task ActionLauncherAsync()
        {
            // Check if there's text in the input box
            if (!string.IsNullOrWhiteSpace(txtBoxAsk.Text))
            {
                // Handle special commands
                if (txtBoxAsk.Text.ToLower().Trim() == "/help") 
                    ShowControl(_helpControl);
                else if (txtBoxAsk.Text.ToLower().Trim() == "/entities") 
                    ShowControl(_EntitiesControl);
                else if (txtBoxAsk.Text.ToLower().Trim() == "/symbolic") 
                    ShowControl(_symbolicProcessor);
                else
                {
                    // Create a request object for the AI model
                    Request request = new Request
                    {
                        model = "mistral-small3.1",
                        messages = new List<Localhost.AI.Core.Models.LLM.Message>
                        {
                            new Localhost.AI.Core.Models.LLM.Message
                            {
                                role = "user",
                                content = txtBoxAsk.Text.Trim()
                            }
                        }
                    };

                    // Call the Ollama API to get a response
                    Response response = await OllamaManager.CallOllamaAsync(_config.DialogServerUrl, request);

                    // Check if we got a valid response
                    if (response != null && response.choices != null && response.choices.Count > 0)
                    {
                        // Build the response text from all choices
                        StringBuilder sb = new StringBuilder();
                        foreach (var choice in response.choices)
                        {
                            sb.AppendLine(choice.message.content);
                        }
                        labelAnswer.Text = sb.ToString();

                        // Create a robot request for text-to-speech
                        RequestRobot req = new RequestRobot
                        {
                            action = "voice",
                            text = labelAnswer.Text,
                            parameters = "",
                            language = "fr"
                        };

                        // Send the text to the robot for voice synthesis
                        RestHelper.PostAsync("http://localhost:8080/api/process", req);
                    }
                    else
                    {
                        // Display error message if no response received
                        labelAnswer.Text = "No response from model.";
                    }
                }
            }
            else 
            {
                // Do nothing if input is empty
            }
        }



        /// <summary>
        /// Displays the specified user control in the main panel and clears the input text.
        /// </summary>
        /// <param name="control">The user control to display.</param>
        private void ShowControl(UserControl control)
        {
            panel1.SuspendLayout();
            panel1.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel1.Controls.Add(control);
            panel1.ResumeLayout();
            txtBoxAsk.Clear();
            txtBoxAsk.Text = "";
            butAsk.Focus();
            txtBoxAsk.Focus();

            labelAnswer.Text = control.Name + " loaded." + Environment.NewLine + "Other line +++";
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControl(_helpControl);
        }

        private void txtBoxAsk_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxAsk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // check if Enter was pressed
            {
                ActionLauncherAsync();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Applies a dark theme to the specified control and all its child controls.
        /// </summary>
        /// <param name="parent">The parent control to apply the dark theme to.</param>
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

        private void deleteCacheToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            try
            { 
                deleteCache();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting cache : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _session.LogSave($"Error deleting cache : {ex.Message}", "Kaonashi.Gui", "ERROR");
            }
        }

        private async Task  deleteCache()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:9200/cache");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
           

        }
    }
}



