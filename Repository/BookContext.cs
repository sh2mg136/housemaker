using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Repository
{

    public class BookContext : DbContext
    {
        public BookContext() : base("DefaultConnection") { }

        public DbSet<Book> Books { get; set; }
    }

}
