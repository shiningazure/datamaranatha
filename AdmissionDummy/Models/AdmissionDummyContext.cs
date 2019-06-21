using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AdmissionDummy.Models
{
    public class AdmissionDummyContext : DbContext
    {
        public AdmissionDummyContext()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<AdmissionDummy.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<AdmissionDummy.Models.Staff> Staffs { get; set; }
    }
}