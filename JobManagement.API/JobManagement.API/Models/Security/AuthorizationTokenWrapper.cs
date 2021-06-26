using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class AuthorizationTokenWrapper : TokenWrapperBase
    {
        private readonly AuthorizationToken AuthToken;
        private string message { get; set; }

        public AuthorizationTokenWrapper(IEncription SEHInstance, AuthorizationToken Token) : base(SEHInstance) => this.AuthToken = Token;

        public AuthorizationTokenWrapper(IEncription CPEInstance, string encodedEncryptedToken) : base(CPEInstance)
        {
            if (string.IsNullOrEmpty(encodedEncryptedToken)) { throw new ArgumentNullException(Message_EmptyToken); }

            try
            {
                string decryptedToken = Decrypt(encodedEncryptedToken);
                this.AuthToken = new AuthorizationToken();
                AuthToken.ParseToken(decryptedToken);
            }
            catch (Exception m)
            {
                message = m.Message;
            }
        }
        public string GetTokenAsString()
        {
            string tokenString = AuthToken.GetTokenString();
            string encryptedToken = Encrypt(tokenString);
            return encryptedToken;
        }
   

        internal bool isValid()
        {
            try
            {
                if (!AuthToken.isValid()) { return false; }

                this.message = "El token es válido.";

                return true;
            }
            catch
            {
                this.message = "Token inválido.";
                return false;
            }
        }

        public TokenValidationMessage ValidateToken()
        {
            return new TokenValidationMessage
            {
                message = this.message,
                isValid = isValid()
            };
        }
    }
}
