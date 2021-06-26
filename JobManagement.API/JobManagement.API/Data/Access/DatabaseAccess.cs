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
        private static string EncryptKey = "Encriptado de la API de Empleos";
        private static string DataSourcePath = AppDomain.CurrentDomain.BaseDirectory + "Connection.dot";

        public void LoadConnection()
        {
            Security Sec = new Security();
            ConnectionString = Sec.SetConnection(DataSourcePath, EncryptKey).Replace("Provider=SQLOLEDB.1;", "");
        }
    }
}