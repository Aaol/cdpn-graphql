using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.Types
{
    public abstract class GraphQlIHaveIdentifierType<T> : GraphQLObjectType<T>
        where T: IHaveIdentifier
    {
        /// <summary>
        ///     Crée une nouvelle instance de classe
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="descriptionForIdentifier"></param>
        /// <returns></returns>
        public GraphQlIHaveIdentifierType(string name, string description, string descriptionForIdentifier) : base(name, description)
        {
            this.Field("id", e => e.Identifier).WithDescription("Identifiant de " + descriptionForIdentifier);
        }
    }
}