namespace Localhost.AI.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides cryptographic utility methods for hashing and encryption operations.
    /// </summary>
    public static class CryptographyManager
    {
        /// <summary>
        /// Computes the SHA256 hash of a file and returns it as a Base64-encoded string.
        /// </summary>
        /// <param name="fullName">The full path to the file to hash.</param>
        /// <returns>A Base64-encoded string representing the SHA256 hash of the file.</returns>
        /// <exception cref="Exception">Thrown when file access or hashing operations fail.</exception>
        public static string SHA256HashFile(string fullName)
        {
            // Create a SHA256 hash algorithm instance
            using (SHA256 SHA256 = SHA256Managed.Create())
            {
                // Open the file for reading and compute its hash
                using (FileStream fileStream = File.OpenRead(fullName))
                    // Convert the hash bytes to a Base64 string for easy storage/transmission
                    return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
            }
        }
        /// <summary>
        /// Computes the SHA256 hash of a text string and returns it as a hexadecimal string.
        /// </summary>
        /// <param name="text">The text string to hash.</param>
        /// <returns>A hexadecimal string representing the SHA256 hash of the input text.</returns>
        /// <exception cref="Exception">Thrown when hashing operations fail.</exception>
        public static string SHA256HashString(string text)
        {
            try
            {
                // Create a SHA256 hash algorithm instance
                SHA256 hash = SHA256.Create();
                
                // Convert the input text to UTF8 bytes and compute the hash
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(text));
                
                // Create a StringBuilder to build the hexadecimal string
                StringBuilder sha256signature = new StringBuilder();
                
                // Convert each byte to a 2-digit hexadecimal string
                for (int i = 0; i < bytes.Length; i++)
                {
                    sha256signature.Append(bytes[i].ToString("x2"));
                }
                
                // Return the complete hexadecimal hash string
                return sha256signature.ToString();
            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during hashing
                throw;
            }
        }

        /// <summary>
        /// Encrypts a text string using AES-256 encryption with the provided password.
        /// </summary>
        /// <param name="text">The text string to encrypt.</param>
        /// <param name="password">The password to use for encryption.</param>
        /// <returns>A Base64-encoded string containing the encrypted text with IV prepended.</returns>
        /// <exception cref="Exception">Thrown when encryption operations fail.</exception>
        public static string AES256EncryptText(string text, string password)
        {
            // Default padding password to ensure consistent key length
            string _password = "abcdefghijklmnopqrstuvwx";

            // Pad the password to exactly 24 characters for AES-256
            password = (password + _password).Substring(0, 24);
            try
            {
                // Convert the password to bytes for the encryption key
                var myKey = Encoding.UTF8.GetBytes(password);
                
                // Create an AES encryption algorithm instance
                using (var AES = Aes.Create())
                {
                    // Create an encryptor using the key and IV
                    using (var encryptor = AES.CreateEncryptor(myKey, AES.IV))
                    {
                        // Create a memory stream to hold the encrypted data
                        using (var msEncrypt = new MemoryStream())
                        {
                            // Create a crypto stream for encryption
                            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                // Write the text to be encrypted
                                swEncrypt.Write(text);
                            }

                            // Get the IV and encrypted data
                            var myAESIv = AES.IV;
                            var decryptedText = msEncrypt.ToArray();
                            
                            // Create a result array that combines IV + encrypted data
                            var result = new byte[myAESIv.Length + decryptedText.Length];

                            // Copy IV to the beginning of the result
                            Buffer.BlockCopy(myAESIv, 0, result, 0, myAESIv.Length);
                            // Copy encrypted data after the IV
                            Buffer.BlockCopy(decryptedText, 0, result, myAESIv.Length, decryptedText.Length);
                            
                            // Return the combined IV + encrypted data as Base64 string
                            return Convert.ToBase64String(result);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Re-throw any exceptions that occur during encryption
                throw;
            }
        }

        /// <summary>
        /// Decrypts a Base64-encoded string that was encrypted using AES-256 encryption.
        /// </summary>
        /// <param name="text">The Base64-encoded encrypted text with IV prepended.</param>
        /// <param name="password">The password used for the original encryption.</param>
        /// <returns>The decrypted text string.</returns>
        /// <exception cref="Exception">Thrown when decryption operations fail.</exception>
        public static string AES256TextDecrypt(string text, string password)
        {
            string _password = "abcdefghijklmnopqrstuvwx";
            password = (password + _password).Substring(0, 24);
            try
            {
                var CryptedText = Convert.FromBase64String(text);
                var myAESIv = new byte[16];
                var myCipher = new byte[16];
                Buffer.BlockCopy(CryptedText, 0, myAESIv, 0, myAESIv.Length);
                Buffer.BlockCopy(CryptedText, myAESIv.Length, myCipher, 0, myAESIv.Length);
                var key = Encoding.UTF8.GetBytes(password);
                using (var AES = Aes.Create())
                {
                    using (var decryptor = AES.CreateDecryptor(key, myAESIv))
                    {
                        string result;
                        using (var msDecrypt = new MemoryStream(myCipher))
                        {
                            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (var srDecrypt = new StreamReader(csDecrypt))
                                {
                                    result = srDecrypt.ReadToEnd();
                                }
                            }
                        }
                        return result;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
