using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmissionDummy.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string NRP { get; set; }
        public string Email { get; set; }
        public string Nomor_Telepon { get; set; }
        public string Alamat { get; set; }
        public string TahunKelulusan { get; set; }
        public string Tanggal_Daftar { get; set; }
        public string Jurusan_Daftar { get; set; }
        public string Fakultas_Daftar { get; set; }
    }
}