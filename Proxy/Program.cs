using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Proxy
{
    public class Page
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }

    public class BookContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public interface IBook : IDisposable
    {
        public Page GetPage(int number);
    }

    public class BookStore : IBook
    {
        private BookContext db;
        public BookStore()
        {
            db = new BookContext();
        }

        public Page GetPage(int number)
        {
            return db.Pages.FirstOrDefault(p=> p.Number == number);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }

    public class BookStoreProxy : IBook
    {
        private List<Page> pages;

        private BookStore BookStore;

        public BookStoreProxy()
        {
            pages = new List<Page>();
        }

        public Page GetPage(int number)
        {
            Page page = pages.FirstOrDefault(p=>p.Number == number);

            if (page == null)
            {
                if (BookStore == null)
                {
                    BookStore = new BookStore();
                }

                page = BookStore.GetPage(number);

                pages.Add(page);
            }

            return page;
        }

        public void Dispose()
        {
            if (BookStore != null)
            {
                BookStore.Dispose();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new BookStoreProxy();

            Page page = book.GetPage(1);//get's from BookStore (db)

            Page page2 = book.GetPage(2);//get's from BookStore (db)

            Page page1 = book.GetPage(1);//get's from BookStoreProxy (pages)
        }
    }
}
