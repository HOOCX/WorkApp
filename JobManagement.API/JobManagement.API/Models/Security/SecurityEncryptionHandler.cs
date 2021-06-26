
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class SecurityEncryptionHandler : IEncription
    {
    

  
        public string CreateHash(string message)
        {

            string coded = Base64Encode(message);
            return coded;
        }

        public string Decrypt(string message)
        {
            return null;
        }

        public string DecryptAndDecode(string encryptedMessage)
        {
            string decrypted = Base64Decode(encryptedMessage);
            return decrypted;
        }

        public string Encrypt(string message)
        {
            return null;
        }

        public string EncryptAndEncode(string message)
        {
            string encrypted = Base64Encode(message);
            return encrypted;
        }

        public static string Base64Encode(string plainText)
        {
            try
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                return Convert.ToBase64String(plainTextBytes);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Base64Decode(string base64EncodedData)
        {
            try
            {
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
