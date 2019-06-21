using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SATDummy.Models
{
    public class User
    {

        public string NRP { get; set; }
        [Key]
        public Guid Id { get; set; }
        public string Nama { get; set; }
        public string Jurusan { get; set; }
        public string Fakultas { get; set; }
        public string Program { get; set; }
        public string IPK { get; set; }
    }
}