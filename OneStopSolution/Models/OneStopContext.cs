using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace OneStopSolution.Models
{
    public class OneStopContext : DbContext
    {
        public OneStopContext() : base("OneStopContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Article> Articles { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<OneStopSolution.Models.Donation> Donations { get; set; }

        public System.Data.Entity.DbSet<OneStopSolution.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<OneStopSolution.Models.JobCategories> JobCategories { get; set; }
    }
}