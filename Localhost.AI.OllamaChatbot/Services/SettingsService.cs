using System;
using System.IO;
using Newtonsoft.Json;
using Localhost.AI.LlmClient.Models;

namespace Localhost.AI.LlmClient.Services
{
    public class SettingsService
    {
        private readonly string _settingsPath;
        private AppSettings _settings = new();

        public SettingsService()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var appFolder = Path.Combine(appDataPath, "OllamaChatbot");
            
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }
            
            _settingsPath = Path.Combine(appFolder, "settings.json");
            LoadSettings();
        }

        public AppSettings Settings => _settings;

        public void LoadSettings()
        {
            try
            {
                if (File.Exists(_settingsPath))
                {
                    var json = File.ReadAllText(_settingsPath);
                    _settings = JsonConvert.DeserializeObject<AppSettings>(json) ?? new AppSettings();
                }
                else
                {
                    _settings = new AppSettings();
                }
            }
            catch
            {
                _settings = new AppSettings();
            }
        }

        public void SaveSettings()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
                File.WriteAllText(_settingsPath, json);
            }
            catch (Exception ex)
            {
                // Handle error - could show a message to user
                throw new InvalidOperationException($"Failed to save settings: {ex.Message}", ex);
            }
        }

        public void UpdateSettings(AppSettings newSettings)
        {
            _settings = newSettings;
            SaveSettings();
        }
    }
}
