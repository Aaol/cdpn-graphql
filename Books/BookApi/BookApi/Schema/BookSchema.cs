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

            this.AddNewType<Author, AuthorObject, AuthorInputObject>();
            this.AddNewType<BookComment, BookCommentObject, BookCommentInputObject>();
            this.AddNewType<Book, BookObject, BookInputObject>();

            this.AddKnownType(rootQuery);
            this.AddKnownType(rootMutation);

            this.Query(rootQuery);
            this.Mutation(rootMutation);
        }
        private void AddNewType<T, U,V>()
        where U: GraphQLObjectType, new()
        where V: GraphQLInputObjectType, new()
        {
            this.AddKnownType(new EntityResponseListObject<T>());
            this.AddKnownType(new EntityResponseObject<T>());
            this.AddKnownType(new U());
            this.AddKnownType(new V());
        }
    }
}