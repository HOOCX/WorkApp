using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class TokenValidationMessage
    {
        public bool isValid { get; set; }
        public string message { get; set; }
    }
}
