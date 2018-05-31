using System.Collections.Generic;
using System.Linq;
using BooksApiDbLib;
using BooksApiDbLib.Models;

namespace BookApi.Services
{
    public interface IBookService
    {
        List<Author> GetAuthors();
    }
}