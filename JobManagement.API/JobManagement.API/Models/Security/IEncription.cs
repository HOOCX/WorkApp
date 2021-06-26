using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public interface IEncription
    {
        string CreateHash(string message);
 
        string EncryptAndEncode(string message);

        string DecryptAndDecode(string encryptedMessage);
 
        string Encrypt(string message);

        string Decrypt(string message);
  
    }
}
