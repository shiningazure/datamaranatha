using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneStopSolution.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime TanggalDaftar { get; set; }
        public string NRP { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public string Jurusan { get; set; }
        public string Fakultas { get; set; }
        public string Program { get; set; }
        public int Angkatan { get; set; }
        public float IPK { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string TempatLahir { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string KodePos { get; set; }
        public string Provinsi { get; set; }
        public string NoTelepon { get; set; }
        public string NoHP { get; set; }
        public string Email { get; set; }
        public DateTime TanggalLulus { get; set; }
        public string SekolahAsal { get; set; }
        public string AlamatSekolah { get; set; }
        public string KotaSekolah { get; set; }
        public string UkuranToga { get; set; }
        public string IkutWisuda { get; set; }
        public string Pembayaran { get; set; }
        public string ImageURL { get; set; }
    }
}