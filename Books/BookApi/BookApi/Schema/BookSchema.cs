using BookApi.Schema.Types;
using GraphQLCore.Type;

namespace BookApi.Schema
{
    public class BookSchema : GraphQLSchema
    {
        public BookSchema()
        {
            Query rootQuery = new Query();
            this.AddKnownType(new GraphQlAuthorObject());

            this.Query(rootQuery);
        }
    }
}