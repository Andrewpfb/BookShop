using BookShop.Data.EF;
using BookShop.Data.Intefaces;
using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Data.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private BookShopContext db;

        public BookRepository(BookShopContext context)
        {
            db = context;
        }
        public void Create(Book item)
        {
            db.Books.Add(item);
        }

        public void Delete(int id)
        {
            db.Books.Remove(db.Books.Find(id));
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return db.Books.Where(predicate);
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
