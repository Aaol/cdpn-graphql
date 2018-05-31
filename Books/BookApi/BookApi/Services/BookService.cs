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
        public List<Author> GetAuthors()
        {
            return this._Entities.Authors.ToList();
        }
        public List<Book> GetBooks()
        {
            return this._Entities.Books.Include(book => book.Author).ToList();
        }
        public Author GetAuthorById(long id)
        {
            return this._Entities.Authors.First(author => author.Identifier == id);
        }
    }
}