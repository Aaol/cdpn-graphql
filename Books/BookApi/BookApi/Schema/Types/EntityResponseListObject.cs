using System.Collections.Generic;
using BookApi.Helpers;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.Types
{
    public class EntityResponseListObject<T> : EntityResponseObject<List<T>>
    {
        public EntityResponseListObject() : base("List<" + typeof(T).Name + ">")
        {

        }
    }
}