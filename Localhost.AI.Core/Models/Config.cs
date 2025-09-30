namespace Localhost.AI.Core.Models
{
    public class Config
    {
        #region "Common"
        public string AppName { get; set; } = "APPx";
        public string? ProjectName { get; set; } = "common";
        public string? Language { get; set; } = "*";
        public string? Category { get; set; }
        public string AppDescription { get; set; } = "Description of the application ";
        public string AppDocumentationUrl { get; set; } = @"https://www.nexai.net";
        public string OllamaUrl { get; set; } = "http://localhost:11434";
        public string? DialogServerUrl { get; set; }
        public string? ECMRootFolder { get; set; } = "C:\\Documents";
        public string? RobotUrl { get; set; }

        #endregion

        #region "Parameters for servers"
        public ESSServerSettings? DataRepository { get; set; }

        public ESSServerSettings? DialogRepository { get; set; }
        public ESSServerSettings? AdminRepository { get; set; }

        #endregion

        #region "Thinking parameters"
        public int LatencyMs { get; set; } = 100;
        #endregion

    }
}
