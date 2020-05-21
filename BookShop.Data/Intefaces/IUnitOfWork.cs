using BookShop.Data.Models;
using System;

namespace BookShop.Data.Intefaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Book's repository.
        /// </summary>
        IRepository<Book> Books { get; }

        /// <summary>
        /// Save changes in database.
        /// </summary>
        public void SaveChanges();
    }
}
