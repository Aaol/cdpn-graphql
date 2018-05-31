using System;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.InputTypes
{
    public class GraphQlAuthorInputObject : GraphQLInputObjectType<Author>
    {
        public GraphQlAuthorInputObject() : base("InputAuthor", "Objet d'entrée pour un auteur")
        {
            this.Field("firstname", e => e.FirstName);
            this.Field("lastname", e => e.LastName);
        }
    }
}