using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Library.Contracts
{
    /// <summary>
    /// IAes
    /// </summary>
    public interface IAes
    {
        /// <summary>
        /// AesDecrypt
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        Task<string> AesDecrypt(string cipherText);

        /// <summary>
        /// AesEncrypt
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        Task<string> AesEncrypt(string plainText);
    }
}
