using System.Collections.Generic;

namespace BookApi.Helpers
{
    /// <summary>
    ///     Classe utilisée pour faire les réponses pour gérer les erreurs
    /// </summary>
    /// <typeparam name="T">Type de l'entité à renvoyer</typeparam>
    public class EntityResponse<T>
    {
        public T Entity { get; private set; }
        public List<string> Errors { get; private set; }
        public List<string> Warnings { get; private set; }
        public string Success { get; private set; }
        public EntityResponse()
        {
            this.Errors = new List<string>();
            this.Warnings = new List<string>();
        }
        public EntityResponse(T entity) : this()
        {
            this.Entity = entity;
        }
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
        public void AddWarning(string error)
        {
            this.Warnings.Add(error);
        }
        public void SetEntity(T entity)
        {
            this.Entity = entity;
        }
        public void SetSuccess(string success)
        {
            this.Success = success;
        }
        public bool HasErrors()
        {
            return this.Errors.Count > 0;
        }
    }
}