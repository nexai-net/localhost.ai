namespace Localhost.AI.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    /// <summary>
    /// Provides utility methods for file system operations and file information retrieval.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Gets the size of a file in bytes.
        /// </summary>
        /// <param name="filePath">The full path to the file.</param>
        /// <returns>The size of the file in bytes, or -1 if an error occurs.</returns>
        public static long GetFileSize(string filePath)
        {
            try
            {
                // Create a FileInfo object to get file information
                FileInfo fileInfo = new FileInfo(filePath);
                
                // Return the file size in bytes
                return fileInfo.Length;
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine($"An error occurred: {ex.Message}");
                
                // Return -1 to indicate an error occurred
                return -1;
            }
        }

        /// <summary>
        /// Gets the creation date and time of a file.
        /// </summary>
        /// <param name="filePath">The full path to the file.</param>
        /// <returns>The creation date and time of the file, or DateTime.MinValue if an error occurs.</returns>
        public static DateTime GetFileCreationDate(string filePath)
        {
            try
            {
                // Create a FileInfo object to get file information
                FileInfo fileInfo = new FileInfo(filePath);
                
                // Return the file creation time
                return fileInfo.CreationTime;
            }
            catch (Exception ex)
            {
                // Log the error to console
                Console.WriteLine($"An error occurred: {ex.Message}");
                
                // Return DateTime.MinValue to indicate an error occurred
                return DateTime.MinValue;
            }
        }
    }
}
