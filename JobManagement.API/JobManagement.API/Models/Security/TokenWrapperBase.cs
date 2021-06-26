using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class TokenWrapperBase
    {
        #region Messages
        protected internal static readonly string Message_EmptyToken = "El token sumistrado no puede ser NULL o estar vacio.";
        protected internal static readonly string Message_InvalidToken = "Token inválido.";
        protected internal static readonly string Message_TokenExpired = "El token ha expirado.";
        #endregion

        IEncription Encryption;

        internal TokenWrapperBase(IEncription CPEInstace)
        {
            Encryption = CPEInstace;
        }

      
        protected internal string Encrypt(string plainTextToken)
        {
            if (string.IsNullOrEmpty(plainTextToken)) { throw new ArgumentNullException(Message_EmptyToken); }

            string encoded = Encryption.EncryptAndEncode(plainTextToken);
            return encoded;
        }
        protected internal string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) { throw new ArgumentNullException(Message_EmptyToken); }

            string decryptedToken = "";
            try
            {
                decryptedToken = Encryption.DecryptAndDecode(encryptedText);
            }
            catch
            {
                throw new InvalidOperationException("Cadena de token inválida.");
            }
            return decryptedToken;
        }
    }
}
