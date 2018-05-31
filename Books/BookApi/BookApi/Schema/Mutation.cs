using BookApi.Services;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema
{
    public class Mutation : ExecuteServiceQueryResolver
    {
        private BookService service = new BookService();

        public Mutation() : base("Mutation", "")
        {
            this.Field("newAuthor"
            , (Author author) => ExecuteServiceQuery<Author, Author>(this.service.AddAuthor, author));
            this.Field("newBook"
            , (Book book, long id) => ExecuteServiceQuery<Book, long, Book>(service.AddBook, id ,book));
            this.Field("newComment"
            , (BookComment comment, long id) => ExecuteServiceQuery<BookComment,long,BookComment>(service.AddBookComment,id,comment));
        }

    }
}