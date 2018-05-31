using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BooksApiDbLib;
using BooksApiDbLib.Models;

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
           Debug.WriteLine("getauthors");
            return this._Entities.Authors.ToList();
        }
        public Author GetFirst()
        {
            return this._Entities.Authors.First();
        }
    }
}