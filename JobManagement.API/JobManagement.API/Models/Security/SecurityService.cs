using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
   public class SecurityService
    {
     

        SecurityEncryptionHandler Encryption = new SecurityEncryptionHandler();

     public AuthorizationTokenWrapper CreateAuthenticationToken(TimeSpan TokenLifeTime, string privateKey)
        {
            var Wrapper = new AuthorizationTokenWrapper(Encryption, new AuthorizationToken
            {
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.Now + TokenLifeTime,
                PrivateKey = privateKey
            });

            return Wrapper;
        }
       public AuthorizationTokenWrapper ParseAuthenticationToken(string token)
        {
         
            var Wrapper = new AuthorizationTokenWrapper(Encryption, token);
            return Wrapper;
        }

   
     


    
    }
}

