using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.EF
{
    public class BookShopContext : DbContext
    {
        /// <summary>
        /// Book object in database.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Context class constructor. Accepts <see cref="DbContextOptions"/>.
        /// </summary>
        /// <param name="options"></param>
        public BookShopContext(DbContextOptions options)
            : base(options) { }
    }
}
