namespace Localhost.AI.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class UniqueIdManager
    {
        public static string GetDocumentUniqueId(string FullName, string Machine)
        {
            string res = "";
            if (File.Exists(FullName) && Machine != null)
            {
                res = CryptographyManager.SHA256HashString(FullName + Machine);
            }
            else
            {
                throw new Exception("File doesn't exist");
            }
            return res;
        }

        public static string GetPageUniqueId(string FullName, string Machine, int PageNumber)
        {
            string res = "";
            if (File.Exists(FullName) && Machine != null)
            {
                res = CryptographyManager.SHA256HashString(FullName + Machine + PageNumber.ToString());
            }
            else
            {
                throw new Exception("File doesn't exist");
            }
            return res;
        }
        public static string GetLineUniqueId(string FullName, string Machine, int PageNumber, int LineNumber)
        {
            string res = "";
            if (File.Exists(FullName) && Machine != null)
            {
                res = CryptographyManager.SHA256HashString(FullName + Machine + PageNumber.ToString() + LineNumber.ToString());
            }
            else
            {
                throw new Exception("File doesn't exist");
            }
            return res;
        }
    }
}
