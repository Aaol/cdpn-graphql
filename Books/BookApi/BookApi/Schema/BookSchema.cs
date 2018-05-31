using System.Collections.Generic;
using BookApi.Schema.Types;
using BookApi.Services;
using BooksApiDbLib;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema
{
    public class BookSchema : GraphQLSchema
    {
        public BookSchema()
        {
            Query rootQuery = new Query();
            this.AddKnownType(new GraphQlAuthorObject());
            this.AddKnownType(new GraphQlBookObject());


            this.AddKnownType(new GraphQlEntityResponse<List<Author>>());
            this.AddKnownType(new GraphQlEntityResponse<Author>());

            this.AddKnownType(new GraphQlEntityResponse<List<Book>>());
            this.AddKnownType(new GraphQlEntityResponse<Book>());


            this.AddKnownType(rootQuery);
            this.Query(rootQuery);
        }
    }
}