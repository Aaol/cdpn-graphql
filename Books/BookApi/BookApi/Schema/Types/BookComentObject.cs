using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.Types
{
    public class BookCommentObject : GraphQlIHaveIdentifierType<BookComment>
    {
        public BookCommentObject() : base("BookComment", "Un commentaire d'un livre", "le commentaire")
        {
            this.Field("comment", e => e.Comment, "Le commentaire");
            this.Field("publishdate", e => e.PublishDate, "La date de publication du commentaire");
            this.Field("book", e => e.Book, "Le livre commenté");
        }
    }
}