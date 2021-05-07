using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebDentalClinic.Models
{
    public class DB_Entities_TAIKHOANBENHNHAN : DbContext
    {
        public DB_Entities_TAIKHOANBENHNHAN() : base("WebPhongKhamNhaKhoaEntities") { }
        public DbSet<TAIKHOANBENHNHAN> taiKhoanBenhNhan { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<demoEntities>(null);
            modelBuilder.Entity<TAIKHOANBENHNHAN>().ToTable("TAIKHOANBENHNHAN");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);


        }

    }
}