using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiDemo.Library.Contracts;
using Microsoft.Extensions.Configuration;

namespace ApiDemo.Library
{
    /// <summary>
    /// Aes
    /// </summary>
    public class Aes : IAes
    {
        #region fields

        private readonly string _aesKey;

        #endregion

        #region constructors

        /// <summary>
        /// Decrypt
        /// </summary>
        /// <param name="configuration"></param>
        public Aes(IConfiguration configuration)
        {
            if (configuration != null)
            {
                _aesKey = configuration["AesKey"];
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// AesDecrypt
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public async Task<string> AesDecrypt(string cipherText)
        {
            return await Task.Run(() => AesDecrypt(cipherText, _aesKey));
        }

        /// <summary>
        /// AesEncrypt
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public async Task<string> AesEncrypt(string plainText)
        {
            return await Task.Run(() => AesEncrypt(plainText, _aesKey));
        }

        private string AesEncrypt(string plainText, string key)
        {
            // Check arguments.
            if (string.IsNullOrEmpty(plainText))
                return plainText;
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("Key");
            byte[][] keys = GetHashKeys(key);
            byte[] encrypted;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = keys[0];
                aesAlg.IV = keys[1];

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);
        }

        private string AesDecrypt(string cipherText, string key)
        {
            // Check arguments.
            if (string.IsNullOrEmpty(cipherText))
            {
                return cipherText;
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("Key");
            }

            var keys = GetHashKeys(key);

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (var aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = keys[0];
                aesAlg.IV = keys[1];

                // Create a decryptor to perform the stream transform.
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        private byte[][] GetHashKeys(string key)
        {
            var result = new byte[2][];
            var enc = Encoding.UTF8;

            using (SHA256 sha2 = new SHA256CryptoServiceProvider())
            {
                var rawKey = enc.GetBytes(key);
                var rawIV = enc.GetBytes(key);

                var hashKey = sha2.ComputeHash(rawKey);
                var hashIV = sha2.ComputeHash(rawIV);

                Array.Resize(ref hashIV, 16);

                result[0] = hashKey;
                result[1] = hashIV;
            }

            return result;
        }

        #endregion
    }
}
