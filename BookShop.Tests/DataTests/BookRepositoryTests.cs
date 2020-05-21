using BookShop.Core.DTO;
using BookShop.Data.Intefaces;
using BookShop.Data.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Tests.DataTests
{
    public class BookRepositoryTests
    {
        private Mock<IRepository<Book>> _bookRepoMock = new Mock<IRepository<Book>>();
        private List<Book> _booksList = new List<Book>()
        {
            new Book() { Id = 1, Name = "first", Description = "book" },
            new Book() { Id = 2, Name = "second", Description = "book" },
            new Book() { Id = 3, Name = "third", Description = "book" }
        };

        private IRepository<Book> _bookRepo;

        private Book _newBook = new Book() { Id = 4, Name = "fourth", Description = "book" };

        [SetUp]
        public void Setup()
        {
            _bookRepoMock.Setup(br => br.Get(1))
                .Returns(_booksList[1]);
            _bookRepoMock.Setup(br => br.GetAll())
                .Returns(_booksList);
            _bookRepoMock.Setup(br => br.Create(It.IsAny<Book>()))
                .Callback((Book newBook) => { _booksList.Add(newBook); })
                .Verifiable();

            _bookRepo = _bookRepoMock.Object;
        }

        [Test]
        public void GetBookByIdTest()
        {
            var result = _bookRepo.Get(1);
            Assert.AreEqual(result, _booksList[1], "Unexpected object");
        }

        [Test]
        public void GetAllBooksTest()
        {
            var result = _bookRepo.GetAll();
            Assert.AreEqual(result, _booksList, "Invalid list");
        }

        [Test]
        public void CreateNewBookTest()
        {
            int oldBooksCount = _booksList.Count();
            _bookRepo.Create(_newBook);
            Assert.IsTrue(_booksList.Count() == ++oldBooksCount, "Count of books doesn't change");
            Assert.AreEqual(_booksList.Last(),_newBook, "Last book isn't last added");
        }
    }
}
