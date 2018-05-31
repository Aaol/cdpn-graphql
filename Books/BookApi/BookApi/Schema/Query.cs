using System;
using System.Collections.Generic;
using System.Linq;
using BookApi.Helpers;
using BookApi.Services;
using BooksApiDbLib;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema
{
    public class Query : ExecuteServiceQueryResolver
    {
        public Query() : base("Query", "")
        {
            BookService service = new BookService();

            this.Field("authors", () => ExecuteServiceQuery<List<Author>>(service.GetAuthors));
            this.Field("author", (long id) => ExecuteServiceQuery<Author, long>(service.GetAuthorById, id));
            
            this.Field("books", () => ExecuteServiceQuery<List<Book>>(service.GetBooks));
            this.Field("book", (long id) => ExecuteServiceQuery<Book, long>(service.GetBookById, id));

            this.Field("comments", (long id) => ExecuteServiceQuery<List<BookComment>,long>(service.GetBookComments, id));
            
        }

       
    }
}