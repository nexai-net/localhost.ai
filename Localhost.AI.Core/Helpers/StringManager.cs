namespace Localhost.AI.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    public static class StringManager
    {

        public static List<string> GetAllStrings(string InputText)
        {
            List<string> res = new List<string>();
            string temp = InputText;
            temp = temp.Replace(',', '\n');
            string[] parts = temp.Split('\n');
            if (temp.Trim().Length == 0) return null;
            foreach (string line in parts)
            {
                res.Add(line.Trim());
            }
            return res;
        }

        public static List<string> GetAllTags(string inputText)
        {
            List<string> tags = new List<string>();
            string temp = inputText;
            if (temp.Trim().Length == 0) return null;
            temp = temp.Replace(';', '\n');
            temp = temp.Replace(',', '\n');
            string[] parts = temp.Split('\n');
            foreach (string line in parts)
            {
                if (line.Length > 1)
                {
                    string newTag = "";
                    char c = line[0];
                    char TagCode = ' ';
                    TagCode = c;
                    if (c == '#') { }
                    else if (c == '!') { }
                    else if (c == '?') { }
                    else if (c == '@') { }
                    else if (c == '!') { }
                    else if (c == '$') { }
                    else if (c == '%') { }
                    else if (c == '-') { }
                    else if (c == '+') { }
                    else if (c == '&') { }
                    else if (c == 'µ') { }
                    else
                    {
                        TagCode = ' ';
                    }

                    if (TagCode == ' ')
                    {
                        newTag = "#" + line.Trim().ToUpper();
                    }
                    else
                    {
                        newTag = line.Trim().ToUpper();
                    }
                    tags.Add(newTag);
                }
                else
                {
                    // DO NOTHING :-) I love that
                }
            }
            return tags;
        }

        public static string ConvertISO88591ToUTF8(string text)
        {
            string res = "";
            try
            {
                byte[] isoBytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(text);
                res = Encoding.UTF8.GetString(isoBytes);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ConvertToUTF8(string text)
        {
            string res = "";
            try
            {
                byte[] utf = System.Text.Encoding.UTF8.GetBytes(text);
                res = System.Text.Encoding.UTF8.GetString(utf);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string StringClean(string text)
        {
            string res = "";
            res = text;
            if (res.Contains('&'))
            {
                res = res.Replace("&#x27;", "'");
                res = res.Replace("&nbsp;", " ");
                res = res.Replace("&lt;", "<");
                res = res.Replace("&gt;", ">");
                res = res.Replace("&amp;", "&");
                res = res.Replace("&quot;", "\"");
                res = res.Replace("&apos;", "'");
                res = res.Replace("&cent;", "¢");
                res = res.Replace("&pound;", "£");
                res = res.Replace("&yen;", "yen");
                res = res.Replace("&euro;", "€");
                res = res.Replace("&copy;", "©");
                res = res.Replace("&reg;", "®");
                res = res.Replace("&#768;", "");
                res = res.Replace("&#769;", "");
                res = res.Replace("&#770;", "");
                res = res.Replace("&#771;", "");
                res = res.Replace("&#039;", "'");
                res = res.Replace("&#34;", "\"");
                res = res.Replace("&agrave;", "à");
                res = res.Replace("&eacute;", "é");
                res = res.Replace("&laquo;", "- ");
                res = res.Replace("&raquo;", "\"");
                res = res.Replace("&acirc;", "à");
                res = res.Replace("&#39;", "'");
                res = res.Replace("&#8217;", "'");
                res = res.Replace("&#xE0;", "à");
                res = res.Replace("&#xE9;", "é");

            }
            return res;
        }

        public static string ConvertHtmlToText(string text)
        {
            string res = "";
            try
            {
                res = WebUtility.HtmlDecode(text);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ConvertHtmlToUTF8(string text)
        {
            string res = "";
            try
            {
                string decodedHtml = WebUtility.HtmlDecode(text);
                Encoding originalEncoding = Encoding.GetEncoding("ISO-8859-1");
                byte[] encodedBytes = originalEncoding.GetBytes(decodedHtml);
                res = Encoding.UTF8.GetString(encodedBytes);
                return res;

            }
            catch (Exception)
            {
                throw;
            }

        }


        public static string Base64Encode(string text)
        {
            try
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string Base64Decode(string text)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(text);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> InputsGet(string text)
        {
            try
            {
                List<string> res = new List<string>();
                string[] parts = text.Split('|');
                res = parts.ToList();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> getDialogText(string text)
        {
            try
            {
                List<string> res = new List<string>();
                string[] parts = text.Split('|');
                res = parts.ToList();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<string> PartsGet(string text)
        {
            try
            {
                List<string> res = new List<string>();
                string[] parts = text.Split(',');
                res = parts.ToList();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string normalizeFileName(string text)
        {
            string input = text;
            input = input.Replace(" ", "_");
            input = input.Replace(",", "_");
            input = input.Replace("\"", "_");
            input = input.Replace("-", "_");
            input = input.Replace('é', 'e');
            input = input.Replace('è', 'e');
            input = input.Replace('ê', 'e');
            input = input.Replace('ë', 'e');
            input = input.Replace('à', 'a');
            input = input.Replace('â', 'a');
            input = input.Replace('ô', 'o');
            input = input.Replace('ö', 'o');
            input = input.Replace('ï', 'i');
            input = input.Replace('î', 'i');
            input = input.Replace('ù', 'u');

            return input;
        }

        public static string normalizeWord(string text)
        {
            string input = text;

            input = input.Replace('é', 'e');
            input = input.Replace('è', 'e');
            input = input.Replace('ê', 'e');
            input = input.Replace('ë', 'e');
            input = input.Replace('à', 'a');
            input = input.Replace('â', 'a');
            input = input.Replace('ô', 'o');
            input = input.Replace('ö', 'o');
            input = input.Replace('ï', 'i');
            input = input.Replace('î', 'i');
            input = input.Replace('ù', 'u');

            return input;
        }

        public static string TagNormalize(string value)
        {
            string input = value;
            input = input.Trim().ToLower();
            input = input.Replace(';', ',');
            input = input.Replace('.', ',');
            input = input.Replace('-', ',');
            input = input.Replace(':', ',');
            input = input.Replace('é', 'e');
            input = input.Replace('è', 'e');
            input = input.Replace('ê', 'e');
            input = input.Replace('ë', 'e');
            input = input.Replace('à', 'a');
            input = input.Replace('ô', 'o');
            input = input.Replace('ö', 'o');
            input = input.Replace('ï', 'i');
            input = input.Replace('î', 'i');
            input = input.Replace('ù', 'u');
            input = input.Replace(' ', '_');
            input = input.Trim().ToLower();
            if (input[0] != '#') input = "#" + input;
            return input;
        }


        public static int WordsCountFromTextLine(string textLine)
        {
            int res = 0;
            char[] delimiters = new char[] { ' ', ',', ';', '.', '\n' };
            string[] words = textLine.Trim().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            res = words.Length;
            return res;
        }

        public static List<string> getTags(List<string> myTags)
        {
            List<string> res = new List<string>();
            if (myTags.Count > 0 && myTags is not null)
            {
                foreach (string value in myTags)
                {
                    string input = TagNormalize(value);
                    input = input.ToLower();
                    res.Add(input);
                }
                return res;
            }
            else return myTags;
        }

        public static List<string> getActions(string input)
        {
            List<string> res = new List<string>();
            var res2 = input.Split('|').ToList<string>();

            return res2;
        }

        public static List<MetaData> getMetaDatas(string input)
        {
            List<MetaData> res = new List<MetaData>();
            if (input.Trim().Length == 0) return res;
            try
            {
                string[] lines = input.Split('|');
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    MetaData nxMetaData = new MetaData();
                    nxMetaData.Label = parts[0].Trim().ToLower();
                    nxMetaData.Value = parts[1].Trim().ToLower();
                    res.Add(nxMetaData);
                }
            }
            catch (Exception)
            {
                return new List<MetaData>();
            }
            return res;
        }
        /// <summary>
        /// Get a list of normalized tags.
        /// </summary>
        /// <param name="input">a normal free writing text</param>
        /// <returns>List of normalized tags</returns>
        public static List<string> getTags(string input)
        {
            List<string> myTags = new List<string>();
            input = input.ToLower();
            if (input.Trim().Length == 0)
            {
                return myTags;
            }
            else
            {
                List<string> myValidatedTags = new List<string>();
                try
                {
                    myTags = input.Split(',').ToList<string>();
                    foreach (string tag in myTags)
                    {
                        string value = TagNormalize(tag);
                        value = value.ToLower();
                        myValidatedTags.Add(value);
                    }
                    return myTags;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
