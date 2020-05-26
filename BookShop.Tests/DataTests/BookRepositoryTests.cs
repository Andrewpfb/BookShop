using BookShop.Data.EF;
using BookShop.Data.Intefaces;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Tests.DataTests
{
    [TestFixture]
    public class BookRepositoryTests
    {
        private BookShopContext _dbTextContext;
        private IRepository<Book> _testBookRepo;

        private readonly Book _newBook = new Book() { Id = 4, Name = "fourth", Description = "book" };

        [OneTimeSetUp]
        public void Setup()
        {
            var testDbOptions = new DbContextOptionsBuilder<BookShopContext>()
                .UseInMemoryDatabase(databaseName: "BookShopDatabaseTest")
                .Options;

            _dbTextContext = new BookShopContext(testDbOptions);
            _dbTextContext.Books.AddRange(new List<Book>()
        {
            new Book() { Id = 1, Name = "first", Description = "book" },
            new Book() { Id = 2, Name = "second", Description = "book" },
            new Book() { Id = 3, Name = "third", Description = "book" }
        });
            _dbTextContext.SaveChanges();
            _testBookRepo = new BookRepository(_dbTextContext);
        }

        [Test]
        public void GetBookByIdTest()
        {
            int id = 1;
            var actual = _testBookRepo.Get(id);
            var expected = _dbTextContext.Books.Where(b => b.Id == id).FirstOrDefault();
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetAllBooksTest()
        {
            var actual = _testBookRepo.GetAll().ToList();
            actual.Should().BeEquivalentTo(_dbTextContext.Books.ToList());
        }

        [Test]
        public void CreateNewBookTest()
        {
            var expectedCount = _dbTextContext.Books.Count()+1;
            _testBookRepo.Create(_newBook);
            _dbTextContext.SaveChanges();
            var actualCount = _dbTextContext.Books.Count();
            Assert.AreEqual(expectedCount, actualCount, "Count of books doesn't change");
        }

        [Test]
        public void DeleteBookTest()
        {
            int expectedCount = _dbTextContext.Books.Count()-1;
            Book deletedBook = _dbTextContext.Books.FirstOrDefault();
            _testBookRepo.Delete(deletedBook.Id);
            _dbTextContext.SaveChanges();
            int actualCount = _dbTextContext.Books.Count();
            Assert.AreEqual(expectedCount, actualCount, "Count of books doesn't change");
            Assert.IsFalse(_dbTextContext.Books.Contains(deletedBook), "Was deleted another book");
        }

        [Test]
        public void UpdateBookTest()
        {
            string newDescription = "updated book";
            Book expected = _dbTextContext.Books.FirstOrDefault();
            expected.Description = newDescription;
            _testBookRepo.Update(expected);
            _dbTextContext.SaveChanges();
            Book actual = _dbTextContext.Books.Where(x => x.Id == expected.Id).FirstOrDefault();
            actual.Should().BeEquivalentTo(expected);
            Assert.AreEqual(newDescription, actual.Description);
        }

        [Test]
        public void FindBookTest()
        {
            int bookId = 2;
            Book expected = _dbTextContext.Books.Find(bookId);
            IEnumerable<Book> actual = _testBookRepo.Find(x => x.Id == bookId);
            Assert.AreEqual(1, actual.Count(), "Returned more than 1 value");
            actual.Should().BeEquivalentTo(expected);
        }
    }
}