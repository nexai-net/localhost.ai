namespace Localhost.AI.Core.Models
{
    public class Performance : Log
    {
        private string _Component { get; set; }
        public int durationMS { get; set; }
        public string ComponentName { get; set; }
        public string ComponentType
        {
            get { return _Component; }
            set
            {
                value = value.ToUpper().Trim();
                if (!(value == "APICALL" || value == "APP" || value == "METHOD" || value == "LLMCALL"))
                {
                    _Component = "PART";
                }
                else
                {
                    _Component = value;
                }
            }
        }
    }
}
