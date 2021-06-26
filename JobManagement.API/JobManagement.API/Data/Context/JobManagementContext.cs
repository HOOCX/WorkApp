using JobManagement.API.Data.Access;
using JobManagement.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobManagement.API.Data.Context
{
    public class JobManagementContext: DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Jobs> Jobs { get; set; }

        public JobManagementContext()
        {
            Database.Connection.ConnectionString = DatabaseAccess.ConnectionString;
        }
    }
}