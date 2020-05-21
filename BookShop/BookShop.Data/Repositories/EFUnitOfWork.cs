using BookShop.Data.EF;
using BookShop.Data.Intefaces;
using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookShop.Data.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BookShopContext db;
        private BookRepository bookRepository;
        private bool disposed;

        public IRepository<Book> Books
        {
            get
            {
                if(bookRepository == null)
                {
                    bookRepository = new BookRepository(db);
                }
                return bookRepository;
            }
        }

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new BookShopContext(options);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {   
            db.SaveChanges();
        }
    }
}
