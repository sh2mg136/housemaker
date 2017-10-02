using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace housemaker.DAL 
{
    public class SqlDbContext : DbContext
    {

        public SqlDbContext() : base("HousemakerDB")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Models.CarouselItem> Photos { get; set; }

    }
}

