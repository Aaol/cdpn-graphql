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
            this.AddKnownType(new GraphQlEntityResponse<List<Author>>());
            this.AddKnownType(rootQuery);
            this.Query(rootQuery);
        }
    }
}