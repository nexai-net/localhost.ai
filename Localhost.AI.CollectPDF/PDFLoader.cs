
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localhost.AI.CollectPDF
{
    using Localhost.AI.Core.Framework;
    using Localhost.AI.Core.Models;
    using Localhost.AI.Core.Helpers;
    public class PDFLoader 
    {

        private SessionManager _session { get; set; }
        private string _PDFFilesRootLocation { get; set; }
        private Config _config { get; set; }
        private string _separator { get; set; } = ":";

        private List<string> _documentsFullName = new List<string>();
        private int _documentsCount = 0;
        private SearchOption _searchOption;


        public PDFLoader(string PDFFilesRootLocation, Config appConfig, SearchOption searchOption, SessionManager session)
        {
            _PDFFilesRootLocation = PDFFilesRootLocation;
            _config = appConfig;
            _documentsFullName = new List<string>();
            _searchOption = searchOption;
            _documentsFullName = System.IO.Directory.GetFiles(PDFFilesRootLocation, "*.pdf", _searchOption).ToList();
            _documentsCount = _documentsFullName.Count;
            _session = session;
        }

        public int DocumentsCount() { return _documentsCount; }
        public List<string> DocumentsList() { return _documentsFullName; }

        /// <summary>
        ///  Loading of PDF File
        /// </summary>
        /// <returns></returns>
        public int DoProcess()
        {
            int ProcessedDocumentsCount = 0;
            DateTime startAt = DateTime.Now;

            foreach (var document in _documentsFullName)
            {
                try
                {
                    if (_session.DocumentExist(document))
                    {
                        Console.WriteLine("Document allready loaded");
                        _session.LogSave(_config.AppName, Environment.MachineName, Environment.UserName, "Document " + document + " allready loaded.", "#pdf,#loader,#document", "WARNING");
                    }
                    else
                    {
                        DocumentProcess(document);
                        _session.LogSave(_config.AppName, Environment.MachineName, Environment.UserName, "Document " + document + " allready loaded.", "#pdf,#loader,#document", "DONE");
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            _session.LogSave(_config.AppName, Environment.MachineName, Environment.UserName, "Processing of all documents from url " + _config.ECMRootFolder, "#pdf,#loader,#document", "INFO");
            DateTime endAt = DateTime.Now;
            TimeSpan duration = endAt - startAt;
            _session.PerformanceSave(_config.AppName, Environment.MachineName, Environment.UserName, "All documents were Processed in " + duration.TotalMilliseconds + "ms.", "#performance,#pdf,#bulk", "INFO", (int)duration.TotalMilliseconds, "PDFALLLOADER", "DOPROCESS");


            return ProcessedDocumentsCount;
        }



        public int DocumentProcess(string document)
        {
            int ExtractedParagraphsCount = 1;
            int pos = 1;
            DateTime startAt = DateTime.Now;



            string hash = CryptographyManager.SHA256HashString(document);
            try
            {
                Localhost.AI.Core.Models.Document doc = new Localhost.AI.Core.Models.Document();
                doc.Id = hash;
                doc.Location = document;
                doc.Type = "PDF";
                doc.Blocks = new List<Block>();
                doc.Comment = document + " is loaded from a PDF file.";
                doc.BlocksCount = 0;
                doc.Date = DateTime.Now;
                doc.UserName = Environment.UserName;
                doc.MachineName = Environment.MachineName;
                doc.Lenght = 0;
                int totalLenght = 0;

                _session.DocumentSave(doc);

                //List<string> strings = Helpers.PDFMgt.PdfToParagraphsGroupBullets(document, null);
                List<string> strings1 = Helpers.PDFMgt.PdfToBlocksWithTitles(document, null);
                foreach (string s in strings1)
                {
                    try
                    {
                        string pid = "";
                        pid = _session.DocumentParagraphSave(s, doc.Location, doc.Id, pos);
                        Console.WriteLine("Doc " + doc.Location + " - Paragraph " + pos + " on " + strings1.Count + "done.");
                        Block block = new Block();
                        block.Id = pid;
                        block.Position = pos;
                        block.Type = "TEXT";
                        doc.Blocks.Add(block);
                        totalLenght += s.Length;
                        pos++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }
                }
                doc.BlocksCount = pos - 1;
                doc.Lenght = totalLenght;
                _session.DocumentSave(doc);


            }
            catch (Exception ex)
            {
                throw ex;
            }

            _session.LogSave(_config.AppName, Environment.MachineName, Environment.UserName, "Document " + document + " well loaded.", "#pdf,#loader,#document", "INFO");
            DateTime endAt = DateTime.Now;
            TimeSpan duration = endAt - startAt;
            _session.PerformanceSave(_config.AppName, Environment.MachineName, Environment.UserName, "Document " + document + " was processed in " + duration.TotalMilliseconds + "ms.", "#performance,#pdf,#bulk", "INFO", (int)duration.TotalMilliseconds, "PDFALLLOADER", "DOCUMENTPROCESS");
            return ExtractedParagraphsCount;
        }
    }
}
