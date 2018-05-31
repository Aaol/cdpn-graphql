using System.Collections.Generic;
using BookApi.Schema.InputTypes;
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
            Mutation rootMutation = new Mutation();
            this.AddKnownType(new DateTimeObject());

            this.AddKnownType(new GraphQlAuthorObject());
            this.AddKnownType(new GraphQlBookObject());


            this.AddKnownType(new EntityResponseListObject<Author>());
            this.AddKnownType(new GraphQlEntityResponse<Author>());

            this.AddKnownType(new EntityResponseListObject<Book>());
            this.AddKnownType(new GraphQlEntityResponse<Book>());

            this.AddKnownType(new GraphQlAuthorInputObject());

            this.AddKnownType(rootQuery);
            this.AddKnownType(rootMutation);

            this.Query(rootQuery);
            this.Mutation(rootMutation);
        }
    }
}