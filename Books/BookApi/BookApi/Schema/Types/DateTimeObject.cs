using System;
using BookApi.Helpers;
using BooksApiDbLib.Models;
using GraphQLCore.Type;

namespace BookApi.Schema.Types
{
    public class DateTimeObject : GraphQLObjectType<DateTime>
    {
        public DateTimeObject() : base("DateTime", "DateTime")
        {
            this.Field("date", e => e.Date.ToShortDateString(), "La date");
            this.Field("time", e => e.TimeOfDay.ToString(), "L'heure");
        }
    }
}