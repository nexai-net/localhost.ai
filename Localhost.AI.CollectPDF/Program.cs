namespace Localhost.AI.CollectPDF
{
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Helpers;
    using Localhost.AI.Core.Models;
    

    public class Program
    {
        static private SessionManager _session;
        static private Config _config;

        static int Main(string[] args)
        {
            Config config = ConfigurationManager.GetFromFile<Config>("config.json");
            Console.WriteLine($"Starting {config.AppName} - {config.AppDescription}");
            Console.WriteLine($"Documentation: {config.AppDocumentationUrl}");
            Console.WriteLine("");
            string AppName = config.AppName ?? "APPx";


            _config = config;
            _session = new SessionManager(_config);
            _session.LogSave("Application started", AppName, "Info");
            try
            {
                PDFLoader pDFLoader = new PDFLoader(_config.ECMRootFolder, _config, SearchOption.AllDirectories, _session);
                _session.LogSave(_config.AppName, Environment.MachineName, Environment.UserName, "DpfLoader is starting", "#info,#pdfloader", "INFO");
                DateTime startAt = DateTime.Now;
                pDFLoader.DoProcess();
                DateTime endAt = DateTime.Now;
                TimeSpan duration = endAt - startAt;
                _session.PerformanceSave(_config.AppName, Environment.MachineName, Environment.UserName, "PDF were well processed in " + duration.TotalSeconds + " seconds.", "#performance,#pdfloader", "PROCESS", (int)duration.TotalMilliseconds, "MAIN", "MAIN");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _session.LogSave(_config.AppName, Environment.MachineName, Environment.UserName, ex.Message, "#error,#pdfloader", "ERROR");
            }

            return 0;
        }
    }
}
