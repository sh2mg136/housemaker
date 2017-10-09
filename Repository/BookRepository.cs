using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{


    public class BookRepository : IDisposable
    {
        private BookContext db = new BookContext();

        public void Save(Book b)
        {
            db.Books.Add(b);
            db.SaveChanges();
        }
        public IEnumerable<Book> List()
        {
            return db.Books;
        }
        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
