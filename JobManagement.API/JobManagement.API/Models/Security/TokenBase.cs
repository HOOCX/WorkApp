using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class TokenBase
    {
        protected readonly string dateTimeFormat = "yyyy-MM-dd HH:mm:ss.000";
        protected readonly char tokenDelimiter = '|';

        protected internal DateTime ParseDate(string date)
        {
            return DateTime.ParseExact(date, dateTimeFormat.Replace("0", "f"), null, System.Globalization.DateTimeStyles.None);
        }

        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
