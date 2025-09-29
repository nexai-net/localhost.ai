namespace Localhost.AI.Core.Models
{
    public class Log : EntityBase
    {
        private string _Type = "";
        public Log() : base()
        {
            Init();
        }
        public Log(string? id) : base(id)
        {
            Init();
        }
        public string AppName { get; set; }
        public string Type
        {
            get { return _Type; }
            set
            {
                value = value.ToUpper().Trim();
                if (!(value == "INFO" || value == "ERROR" || value == "WARNING" || value == "ALERT" || value == "OK" || value == "DONE" || value == "PERF"))
                {
                    _Type = "INFO";
                }
                else
                {
                    _Type = value;
                }
            }
        }

        private void Init()
        {
                ///////
        }
       
    }

}
