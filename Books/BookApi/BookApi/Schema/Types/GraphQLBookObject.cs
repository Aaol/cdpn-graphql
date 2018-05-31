using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.Types
{
    public class GraphQlBookObject : GraphQlIHaveIdentifierType<Book>
    {
        public GraphQlBookObject() : base("Book", "livre", "livre")
        {
            this.Field("author", e => e.Author, "L'auteur du libre");
            this.Field("price", e => e.Price, "Le prix du livre");
            this.Field("publishdate", e => e.PublishDate, "La date de publication du livre");
            this.Field("title", e => e.Title, "Le titre du livre");
            this.Field("type", e => e.Type, "Le genre du livre");
        }
    }
}