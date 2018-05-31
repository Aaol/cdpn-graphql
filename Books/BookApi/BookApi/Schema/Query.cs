using System;
using System.Collections.Generic;
using System.Linq;
using BookApi.Helpers;
using BookApi.Services;
using BooksApiDbLib;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema
{
    public class Query : GraphQLObjectType
    {
        public Query() : base("Query", "")
        {
            BookService service = new BookService();

            this.Field("authors", () => ExecuteServiceQuery<List<Author>>(service.GetAuthors));
            this.Field("author", (long id) => ExecuteServiceQuery<Author, long>(service.GetAuthorById, id));
            
            this.Field("books", () => ExecuteServiceQuery<List<Book>>(service.GetBooks));
            this.Field("book", (long id) => ExecuteServiceQuery<Book, long>(service.GetBookById, id));
            
        }

        /// <summary>
        ///     Méthode appelée pour exécuter une fonction du service, et qui renvoie la réponse sous la forme d'EntityResponse
        /// </summary>
        /// <param name="func">Fonction a appeler dans le service</param>
        /// <param name="value">Valeur à fournir à la fonction</param>
        /// <typeparam name="T">Valeur de sortie</typeparam>
        /// <typeparam name="U">Valeur d'entrée</typeparam>
        /// <returns></returns>
        public EntityResponse<T> ExecuteServiceQuery<T, U>(Func<U, T> func, U value)
        {
            EntityResponse<T> response = new EntityResponse<T>();
            try
            {
                response.SetEntity(func.Invoke(value));
                response.SetSuccess("mon beau succes");
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
                response.SetSuccess("mon beau succes");

            }
            catch (System.Exception e)
            {
                response.AddError(e.Message);
            }
            return response;
        }
    }
}