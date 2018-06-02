using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Repository
{

    public class BookContext : DbContext
    {
        public BookContext() : base("BooksDB") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Book> Books { get; set; }
    }


    public class BookInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            var books = new List<Repository.Book>();
            var book = new Repository.Book()
            {
                Name = "Война и мир",
                AuthorName = "Толстой Лев Николаевич",
                PublishYear = 1869
            };
            books.Add(book);
            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();
        }
    }


}
