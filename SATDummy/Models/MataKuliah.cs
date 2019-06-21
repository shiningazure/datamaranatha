using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SATDummy.Models
{
    public class MataKuliah
    {
        [Key]
        public Guid Id { get; set; }
        public string KodeMataKuliah { get; set; }
        public string NamaMataKuliah { get; set; }
        public int SKS { get; set; }

    }
}