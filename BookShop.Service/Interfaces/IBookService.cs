using BookShop.Core.DTO;

namespace BookShop.Service.Interfaces
{
    public interface IBookService : ICommonService<BookDTO>
    {
        public void TestMethod();
    }
}
