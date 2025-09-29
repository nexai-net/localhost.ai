using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Localhost.AI.LlmClient.Models;
using Localhost.AI.LlmClient.Services;

namespace Localhost.AI.LlmClient
{
    public partial class SettingsWindow : Window
    {
        private readonly SettingsService _settingsService;
        private readonly OllamaService _ollamaService;
        private AppSettings _currentSettings;

        public SettingsWindow(SettingsService settingsService, OllamaService ollamaService)
        {
            InitializeComponent();
            _settingsService = settingsService;
            _ollamaService = ollamaService;
            _currentSettings = new AppSettings
            {
                OllamaUrl = _settingsService.Settings.OllamaUrl,
                DefaultModel = _settingsService.Settings.DefaultModel,
                UserName = _settingsService.Settings.UserName,
                BotName = _settingsService.Settings.BotName,
                AutoScroll = _settingsService.Settings.AutoScroll,
                ShowTimestamps = _settingsService.Settings.ShowTimestamps
            };

            DataContext = _currentSettings;
            LoadAvailableModels();
        }

        private async void LoadAvailableModels()
        {
            try
            {
                _ollamaService.SetBaseUrl(_currentSettings.OllamaUrl);
                var models = await _ollamaService.GetAvailableModelsAsync();
                
                ModelComboBox.ItemsSource = models;
                if (models.Any() && string.IsNullOrEmpty(_currentSettings.DefaultModel))
                {
                    ModelComboBox.SelectedItem = models.First();
                }
            }
            catch
            {
                // If we can't load models, just use the current setting
            }
        }

        private async void TestConnection_Click(object sender, RoutedEventArgs e)
        {
            TestConnectionButton.IsEnabled = false;
            TestConnectionButton.Content = "Testing...";

            try
            {
                _ollamaService.SetBaseUrl(_currentSettings.OllamaUrl);
                var isConnected = await _ollamaService.TestConnectionAsync();

                if (isConnected)
                {
                    MessageBox.Show("Connection successful!", "Test Connection", 
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    // Reload models after successful connection
                    LoadAvailableModels();
                }
                else
                {
                    MessageBox.Show("Connection failed. Please check the URL and ensure Ollama is running.", 
                                  "Test Connection", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection test failed: {ex.Message}", "Error", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                TestConnectionButton.IsEnabled = true;
                TestConnectionButton.Content = "Test Connection";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Update settings from UI
                _currentSettings.OllamaUrl = OllamaUrlTextBox.Text.Trim();
                _currentSettings.DefaultModel = ModelComboBox.Text.Trim();
                _currentSettings.UserName = UserNameTextBox.Text.Trim();
                _currentSettings.BotName = BotNameTextBox.Text.Trim();
                _currentSettings.AutoScroll = AutoScrollCheckBox.IsChecked ?? true;
                _currentSettings.ShowTimestamps = ShowTimestampsCheckBox.IsChecked ?? true;

                // Validate settings
                if (string.IsNullOrWhiteSpace(_currentSettings.OllamaUrl))
                {
                    MessageBox.Show("Please enter a valid Ollama URL.", "Validation Error", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(_currentSettings.UserName))
                {
                    MessageBox.Show("Please enter your name.", "Validation Error", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(_currentSettings.BotName))
                {
                    MessageBox.Show("Please enter the assistant name.", "Validation Error", 
                                  MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Save settings
                _settingsService.UpdateSettings(_currentSettings);
                
                MessageBox.Show("Settings saved successfully!", "Success", 
                              MessageBoxButton.OK, MessageBoxImage.Information);
                
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save settings: {ex.Message}", "Error", 
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
