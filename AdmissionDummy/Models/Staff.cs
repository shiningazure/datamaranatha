using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionDummy.Models
{
    public class Staff
    {
        [Key]
        public Guid Id { get; set; }
        public string NIK { get; set; }
        public string Email { get; set; }
        public string Nomor_Telepon { get; set; }
        public string Role { get; set; }
    }
}