using AutoMapper;
using BookShop.Core.DTO;
using BookShop.Data.Intefaces;
using BookShop.Data.Models;
using BookShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void Add(BookDTO addingObject)
        {
            _db.Books.Create(_mapper.Map<Book>(addingObject));
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Books.Delete(id);
        }

        public IEnumerable<BookDTO> Find(Func<BookDTO, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public BookDTO Get(int id)
        {
            return _mapper.Map<BookDTO>(_db.Books.Get(id));
        }

        public IEnumerable<BookDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<BookDTO>>(_db.Books.GetAll());
        }

        public void TestMethod()
        {
            throw new NotImplementedException();
        }

        public void Update(BookDTO updatingObject)
        {
            throw new NotImplementedException();
        }
    }
}
