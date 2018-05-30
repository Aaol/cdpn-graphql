using System;
using System.Collections.Generic;
using BookApi.Helpers;
using BookApi.Services;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema
{
    public class Query : GraphQLObjectType
    {
        private BookService Service { get; set; }

        public Query() : base("Query", "")
        {
            this.Field("authors", () => ExecuteServiceQuery<List<Author>>(Service.GetAuthors));
        }

        /// <summary>
        ///     Méthode appelée pour exécuter une fonction du service, et qui renvoie la réponse sous la forme d'EntityResponse
        /// </summary>
        /// <param name="func">Fonction a appeler dans le service</param>
        /// <param name="value">Valeur à fournir à la fonction</param>
        /// <typeparam name="T">Valeur de sortie</typeparam>
        /// <typeparam name="U">Valeur d'entrée</typeparam>
        /// <returns></returns>
        public EntityResponse<T> ExecuteServiceQuery<T,U>(Func<U,T> func, U value)
        {
            EntityResponse<T> response = new EntityResponse<T>();
            try
            {
                response.SetEntity(func.Invoke(value));
            }
            catch (System.Exception e)
            {
                response.AddError(e.Message);
            }
            return response;
        }
        /// <summary>
        ///     Méthode appelée pour exécuter une fonction du service, et qui renvoie la réponse sous la forme d'EntityResponse
        /// </summary>
        /// <param name="func">Fonction a appeler dans le service</param>
        /// <param name="value">Valeur à fournir à la fonction</param>
        /// <typeparam name="T">Valeur de sortie</typeparam>
        /// <returns></returns>
        public EntityResponse<T> ExecuteServiceQuery<T>(Func<T> func)
        {
            EntityResponse<T> response = new EntityResponse<T>();
            try
            {
                response.SetEntity(func.Invoke());
            }
            catch (System.Exception e)
            {
                response.AddError(e.Message);
            }
            return response;
        }
    }
}