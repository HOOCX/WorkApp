using JobManagement.API.Models.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JobManagement.API.Data.Access
{
    public class DatabaseAccess
    {
        public static string ConnectionString { get; private set; }


        public void LoadConnection()
        {
     
            ConnectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        }
    }
}