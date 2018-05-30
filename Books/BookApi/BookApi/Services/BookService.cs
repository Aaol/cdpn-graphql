using System.Collections.Generic;
using System.Linq;
using BooksApiDbLib;
using BooksApiDbLib.Models;

namespace BookApi.Services
{
    public class BookService
    {
        private BookContext Entities {get;set;}
        public BookService(BookContext entities)
        {
            this.Entities = entities;
        }
        public List<Author> GetAuthors()
        {
            return this.Entities.Authors.ToList();
        }
    }
}