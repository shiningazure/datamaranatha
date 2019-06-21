using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SATDummy.Models
{
    public class SATDummyContext : DbContext
    {
        public SATDummyContext()
        {

        }

        public System.Data.Entity.DbSet<SATDummy.Models.MataKuliah> MataKuliahs { get; set; }

        public System.Data.Entity.DbSet<SATDummy.Models.User> Users { get; set; }
    }
}