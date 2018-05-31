using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BooksApiDbLib;
using BooksApiDbLib.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Services
{
    public class BookService
    {
        private BookContext _Entities = new BookContext();
        public BookService()
        {
        }
        #region Authors

        public List<Author> GetAuthors()
        {
            return this._Entities.Authors.ToList();
        }

        public Author GetAuthorById(long id)
        {
            return this._Entities.Authors.First(author => author.Identifier == id);
        }

        public Author AddAuthor(Author author)
        {
            this._Entities.Authors.Add(author);
            this._Entities.SaveChanges();
            return author;
        }

        #endregion

        #region Books

        public List<Book> GetBooks()
        {
            return this._Entities.Books.Include(book => book.Author).ToList();
        }
        public Book GetBookById(long id)
        {
            return this._Entities.Books.Include(book => book.Author).First(book => book.Identifier == id);
        }

        public Book AddBook(Book book)
        {
            this._Entities.Books.Add(book);
            this._Entities.SaveChanges();
            return book;
        }

        #endregion

    }
}