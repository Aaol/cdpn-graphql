using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.Types
{
    public class GraphQlAuthorObject : GraphQlIHaveIdentifierType<Author>
    {
        public GraphQlAuthorObject() : base("Author", "L'auteur d'un livre", "l'auteur")
        {
            this.Field("firstname", e => e.FirstName, "Le prénom de l'auteur");
            this.Field("lastname", e => e.LastName, "Le nom de l'auteur");
            this.Field("birthdate", e => e.BirthDate, "La date de naissance de l'auteur");
        }
    }
}