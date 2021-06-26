using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobManagement.API.Data.Models
{
    [Table("JOBS")]
    public class Jobs
    {
        [Column("ID"), Key]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("USER_ID")]
        public int User_Id { get; set; }

        [Column("PHOTO")]
        public string Photo { get; set; }

        [Column("STATE")]
        public int State { get; set; }
    }
}