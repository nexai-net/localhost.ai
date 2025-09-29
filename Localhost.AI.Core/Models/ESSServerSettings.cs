namespace Localhost.AI.Core.Models
{
    public class ESSServerSettings
    {
        public string? Url { get; set; } = "http://localhost:9200";
        public string? Layer { get; set; } = "Default";
        public string? Prefix { get; set; } = "";
        public string? Password { get; set; }
        public string? User { get; set; }
    }
}
