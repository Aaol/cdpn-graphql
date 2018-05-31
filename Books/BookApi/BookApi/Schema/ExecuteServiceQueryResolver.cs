using System;
using BookApi.Helpers;
using GraphQLCore.Type;

namespace BookApi.Schema
{
    public abstract class ExecuteServiceQueryResolver : GraphQLObjectType
    {
        public ExecuteServiceQueryResolver(string name, string description) : base(name, description)
        {
        }
         /// <summary>
        ///     Méthode appelée pour exécuter une fonction du service, et qui renvoie la réponse sous la forme d'EntityResponse
        /// </summary>
        /// <param name="func">Fonction a appeler dans le service</param>
        /// <param name="value">Valeur à fournir à la fonction</param>
        /// <typeparam name="T">Valeur de sortie</typeparam>
        /// <typeparam name="U">Valeur d'entrée</typeparam>
        /// <returns></returns>
        protected EntityResponse<T> ExecuteServiceQuery<T, U>(Func<U, T> func, U value)
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
        /// Méthode appelée pour exécuter une fonction du service, et qui renvoie la réponse sous la forme d'EntityResponse
        /// </summary>
        /// <param name="func">Fonction à appeler</param>
        /// <param name="firstParam">Premier paramètre de la fonction</param>
        /// <param name="secondParam">Deuxième paramètre de la fonction</param>
        /// <typeparam name="T">Type de retour</typeparam>
        /// <typeparam name="U">Type du premier paramètre</typeparam>
        /// <typeparam name="V">Type du second paramètre</typeparam>
        /// <returns></returns>
        protected EntityResponse<T> ExecuteServiceQuery<T, U, V>(Func<U, V, T> func, U firstParam, V secondParam)
        {
            EntityResponse<T> response = new EntityResponse<T>();
            try
            {
                response.SetEntity(func.Invoke(firstParam,secondParam));
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
        protected EntityResponse<T> ExecuteServiceQuery<T>(Func<T> func)
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