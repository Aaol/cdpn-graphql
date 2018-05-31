using System;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.InputTypes
{
    public class BookCommentInputObject : GraphQLInputObjectType<BookComment>
    {
        public BookCommentInputObject() : base("InputBookComment", "Objet d'entrée pour un Commentaire")
        {
            this.Field("comment", e => e.Comment);
        }
    }
}