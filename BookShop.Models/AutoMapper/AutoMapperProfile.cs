using AutoMapper;
using BookShop.Core.DTO;
using BookShop.Data.Models;

namespace BookShop.Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region From Entity to DTO

            CreateMap<Book, BookDTO>();

            #endregion

            #region From DTO to Entity

            CreateMap<BookDTO, Book>();

            #endregion
        }
    }
}
