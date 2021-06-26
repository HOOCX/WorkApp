using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class AuthorizationToken : TokenBase
    {
        public string PrivateKey { get; set; }
    

  
        internal bool isValid()
        {
            //Si las fechas son inválidas.
            if (this.CreationDate == DateTime.MinValue || this.ExpirationDate == DateTime.MinValue) { return false; }

            //Si la fecha de creación es mayor a la fecha actual.
            if (this.CreationDate > DateTime.Now) { return false; }

            //Si el token está vencido.
            if (WasExpired()) { return false; }

            return true;
        }

        internal void ParseToken(string tokenString)
        {
            if (String.IsNullOrWhiteSpace(tokenString))
            {
                throw new ArgumentNullException("La cadena de token no pueder ser null, star vacaia o contener caracteres en blanco.");
            }
            string[] values = tokenString.Split(tokenDelimiter);

            PrivateKey = values[0];
            CreationDate = ParseDate(values[1]);
            ExpirationDate = ParseDate(values[2]);
        }
        public string GetTokenString()
        {
            var token = this;
            string tokenString = $"{token.PrivateKey}|{token.CreationDate.ToString(dateTimeFormat)}|{token.ExpirationDate.ToString(dateTimeFormat)}";
            return tokenString;
        }

        public bool WasExpired() => DateTime.Now > this.ExpirationDate;
    }
}