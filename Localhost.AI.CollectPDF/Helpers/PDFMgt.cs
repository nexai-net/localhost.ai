

namespace Localhost.AI.CollectPDF.Helpers
{
    using iText;
    using iText.Kernel.Pdf;
    using iText.Kernel.Pdf.Canvas.Parser;
    using iText.Kernel.Pdf.Canvas.Parser.Listener;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public static class PDFMgt
    {
        public static string PdfToString(string pdfPath, string? password = null, bool includePageMarkers = false)
        {
            if (!File.Exists(pdfPath))
                throw new FileNotFoundException("PDF not found.", pdfPath);

            var props = new ReaderProperties();
            if (!string.IsNullOrEmpty(password))
                props.SetPassword(Encoding.UTF8.GetBytes(password));

            using var reader = new PdfReader(pdfPath, props);
            using var pdfDoc = new PdfDocument(reader);

            var sb = new StringBuilder(capacity: pdfDoc.GetNumberOfPages() * 1024);

            for (int pageNum = 1; pageNum <= pdfDoc.GetNumberOfPages(); pageNum++)
            {
                if (includePageMarkers)
                    sb.AppendLine($"--- Page {pageNum} ---");

                ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                string text = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pageNum), strategy);

                // normalize line endings, trim trailing whitespace per page
                text = text.Replace("\r\n", "\n").Replace("\r", "\n").TrimEnd();

                sb.AppendLine(text);
                if (includePageMarkers) sb.AppendLine(); // extra gap after page
            }

            return sb.ToString();
        }
        public static List<string> PdfToParagraphsGroupBullets(string pdfPath, string? password = null)
        {
            if (!File.Exists(pdfPath))
                throw new FileNotFoundException("PDF not found.", pdfPath);

            // Open PDF (supports encrypted PDFs)
            var props = new ReaderProperties();
            if (!string.IsNullOrEmpty(password))
                props.SetPassword(Encoding.UTF8.GetBytes(password));

            using var reader = new PdfReader(pdfPath, props);
            using var pdfDoc = new PdfDocument(reader);

            // Extract raw text (page by page), keep a blank line between pages
            var raw = new StringBuilder(pdfDoc.GetNumberOfPages() * 1024);
            for (int p = 1; p <= pdfDoc.GetNumberOfPages(); p++)
            {
                var strategy = new LocationTextExtractionStrategy();
                string pageText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(p), strategy);
                pageText = pageText.Replace("\r\n", "\n").Replace("\r", "\n").TrimEnd();
                raw.AppendLine(pageText);
                raw.AppendLine(); // ensure page gap -> paragraph boundary if needed
            }

            // 1) Repair common hyphenated line breaks: "exam-\nple" -> "example"
            string text = Regex.Replace(raw.ToString(), @"(?<=\p{L})-\n(?=\p{L})", "");

            // 2) Split into physical lines for parsing
            var lines = text.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n');

            // Bullet line detector (•, -, – , —, or numbered/lettered like "1. ", "2) ", "a) ", "i. ")
            var bulletStart = new Regex(@"^\s*(?:[\u2022\u2023\u25E6\u2043\u2219\-–—•]|(?:\d+|[a-zA-Z]|[ivxlcdmIVXLCDM]+)[\.\)])\s+");
            // Continuation lines for bullets: indented by 2+ spaces
            var bulletContinuation = new Regex(@"^\s{2,}\S");

            var result = new List<string>();
            var para = new StringBuilder();
            var bulletItems = new List<string>();
            bool inBulletBlock = false;

            void FlushNormal()
            {
                if (para.Length > 0)
                {
                    result.Add(para.ToString().Trim());
                    para.Clear();
                }
            }

            void FlushBullets()
            {
                if (bulletItems.Count > 0)
                {
                    // Keep one string for the whole list; items separated by newlines
                    result.Add(string.Join("\n", bulletItems).Trim());
                    bulletItems.Clear();
                }
                inBulletBlock = false;
            }

            foreach (var rawLine in lines)
            {
                string line = rawLine.TrimEnd();

                if (string.IsNullOrWhiteSpace(line))
                {
                    // Blank line -> end of current paragraph or bullet block
                    if (inBulletBlock) FlushBullets();
                    FlushNormal();
                    continue;
                }

                if (bulletStart.IsMatch(line))
                {
                    // Start or continue a bullet block
                    if (!inBulletBlock)
                    {
                        // close any running normal paragraph
                        FlushNormal();
                        inBulletBlock = true;
                    }
                    bulletItems.Add(line.Trim());
                    continue;
                }

                if (inBulletBlock && bulletContinuation.IsMatch(rawLine))
                {
                    // Continuation of the previous bullet item (wrapped line)
                    if (bulletItems.Count > 0)
                        bulletItems[bulletItems.Count - 1] += " " + line.Trim();
                    continue;
                }

                // Non-bullet content
                if (inBulletBlock)
                    FlushBullets(); // close bullet block before starting normal text

                // Join soft line breaks with spaces inside a normal paragraph
                if (para.Length > 0) para.Append(' ');
                para.Append(line.Trim());
            }

            // Flush any remaining content
            if (inBulletBlock) FlushBullets();
            FlushNormal();

            // Optional: drop empty entries (defensive)
            result = result.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            return result;
        }

        public static List<string> PdfToBlocksWithTitles(string pdfPath, string? password = null)
        {
            if (!File.Exists(pdfPath))
                throw new FileNotFoundException("PDF not found.", pdfPath);

            // Open (supports encrypted PDFs via password)
            var props = new ReaderProperties();
            if (!string.IsNullOrEmpty(password))
                props.SetPassword(Encoding.UTF8.GetBytes(password));

            using var reader = new PdfReader(pdfPath, props);
            using var pdfDoc = new PdfDocument(reader);

            // 1) Extract raw text page by page, add a blank line between pages.
            var raw = new StringBuilder(pdfDoc.GetNumberOfPages() * 1024);
            for (int p = 1; p <= pdfDoc.GetNumberOfPages(); p++)
            {
                var strategy = new LocationTextExtractionStrategy();
                string pageText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(p), strategy);
                pageText = pageText.Replace("\r\n", "\n").Replace("\r", "\n").TrimEnd();
                raw.AppendLine(pageText);
                raw.AppendLine();
            }

            // 2) Fix common hyphenated line breaks: "exam-\nple" -> "example"
            string text = Regex.Replace(raw.ToString(), @"(?<=\p{L})-\n(?=\p{L})", "");

            // 3) Work line-by-line
            var lines = text.Split('\n');

            // Bullet/numbered list detectors
            var bulletStart = new Regex(@"^\s*(?:[\u2022\u2023\u25E6\u2043\u2219•\-–—]|(?:\d+(\.\d+)*|[A-Za-z]|[ivxlcdmIVXLCDM]+)[\.\)])\s+");
            var bulletContinuation = new Regex(@"^\s{2,}\S"); // indented continuation

            // Result + state
            var result = new List<string>();
            var currentPara = new StringBuilder();
            var bulletItems = new List<string>();
            bool inBulletBlock = false;

            // Helpers
            static bool IsLikelyTitle(string line)
            {
                var t = line.Trim();
                if (t.Length == 0) return false;

                // Avoid lines that look like sentences
                if (Regex.IsMatch(t, @"[.!?]\s*$")) return false;

                // Uppercase ratio (ignore non-letters)
                int letters = t.Count(char.IsLetter);
                int uppers = t.Count(char.IsUpper);
                double upperRatio = letters > 0 ? (double)uppers / letters : 0;

                // Numbered/outlined headings like "1. Intro", "2.1 Scope", "A) Title", "IV. Methods"
                bool numbered = Regex.IsMatch(t, @"^\s*(?:\d+(\.\d+)*|[IVXLCDM]+|[A-Z])[\.\)]\s+\S+");

                // Common section words
                bool sectionWord = Regex.IsMatch(t, @"^(abstract|résumé|summary|introduction|conclusion|references|bibliography|contents|table of contents)\b",
                                                 RegexOptions.IgnoreCase);

                // Shortish, capital-ish, or explicit numbering
                bool lengthOk = t.Length <= 80;
                bool capsish = upperRatio >= 0.7 && t.Length >= 4;

                // A colon at the end often indicates a heading too (keep allowed)
                bool looksTitle = lengthOk && (numbered || sectionWord || capsish);

                return looksTitle;
            }

            void FlushNormal()
            {
                if (currentPara.Length > 0)
                {
                    result.Add(currentPara.ToString().Trim());
                    currentPara.Clear();
                }
            }

            void FlushBullets()
            {
                if (bulletItems.Count > 0)
                {
                    result.Add(string.Join("\n", bulletItems).Trim());
                    bulletItems.Clear();
                }
                inBulletBlock = false;
            }

            foreach (var rawLine in lines)
            {
                string line = rawLine.TrimEnd();

                if (string.IsNullOrWhiteSpace(line))
                {
                    if (inBulletBlock) FlushBullets();
                    FlushNormal();
                    continue;
                }

                // Title detection first; titles must stand alone
                if (IsLikelyTitle(line))
                {
                    if (inBulletBlock) FlushBullets();
                    FlushNormal();
                    result.Add(line.Trim());
                    continue;
                }

                // Bullet list handling
                if (bulletStart.IsMatch(line))
                {
                    if (!inBulletBlock)
                    {
                        FlushNormal();
                        inBulletBlock = true;
                    }
                    bulletItems.Add(line.Trim());
                    continue;
                }

                if (inBulletBlock && bulletContinuation.IsMatch(rawLine))
                {
                    // Continuation of previous bullet item
                    if (bulletItems.Count > 0)
                        bulletItems[^1] += " " + line.Trim();
                    continue;
                }

                // Normal paragraph text: join soft line-breaks with spaces
                if (inBulletBlock) FlushBullets();
                if (currentPara.Length > 0) currentPara.Append(' ');
                currentPara.Append(line.Trim());
            }

            // Final flush
            if (inBulletBlock) FlushBullets();
            FlushNormal();

            // Remove empties just in case
            return result.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
        }
    }

}
