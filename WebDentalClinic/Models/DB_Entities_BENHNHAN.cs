using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebDentalClinic.Models
{
    public class DB_Entities_BENHNHAN : DbContext
    {
        public DB_Entities_BENHNHAN() : base("WebPhongKhamNhaKhoaEntities") { }
        public DbSet<BENHNHAN> benhNhan { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<demoEntities>(null);
            modelBuilder.Entity<BENHNHAN>().ToTable("BENHNHAN");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);


        }

    }
}