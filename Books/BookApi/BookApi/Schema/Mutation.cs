using BookApi.Services;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema
{
    public class Mutation : GraphQLObjectType
    {
        private BookService service = new BookService();

        public Mutation() : base("Mutation", "")
        {
            this.Field("newAuthor"
            , (Author author) => this.service.AddAuthor(author));
        }

    }
}