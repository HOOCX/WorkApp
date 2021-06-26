using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobManagement.API.Data.Models
{
    [Table("USERS")]
    public class Users
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("USERNAME")]
        public string UserName { get; set; }

        [Column("PASSWORD")]
        public string Password { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("ROLE")]
        public int Role { get; set; }

    }
}