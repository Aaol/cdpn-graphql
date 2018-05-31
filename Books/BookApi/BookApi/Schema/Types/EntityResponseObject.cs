using BookApi.Helpers;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.Types
{
    public class EntityResponseObject<T> : GraphQLObjectType<Helpers.EntityResponse<T>>
    {
        public EntityResponseObject() : base("EntityReponse<"+ typeof(T).Name +">", "Objet contenant l'objet de retour dans entity et d'autres informations")
        {
            this.Field("entity", e => e.Entity, "L'objet de retour de la requête");
            this.Field("errors", e => e.Errors, "Les erreurs liés à la requete");
            this.Field("warnings", e => e.Warnings, "Les avertissements liés à la requête");
            this.Field("success", e => e.Success, "Le message de succès lié à la requête");
        }
        public EntityResponseObject(string typeName) : base("EntityReponse<"+ typeName +">", "Objet contenant l'objet de retour dans entity et d'autres informations")
        {
            this.Field("entity", e => e.Entity, "L'objet de retour de la requête");
            this.Field("errors", e => e.Errors, "Les erreurs liés à la requete");
            this.Field("warnings", e => e.Warnings, "Les avertissements liés à la requête");
            this.Field("success", e => e.Success, "Le message de succès lié à la requête");
        }
    }
}