using System;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.InputTypes
{
    public class BookInputObject : GraphQLInputObjectType<Book>
    {
        public BookInputObject() : base("InputBook", "Objet d'entrée pour un livre")
        {
            this.Field("title", e => e.Title);
            this.Field("price", e => e.Price);
            this.Field("type", e => e.Type);
        }
    }
}