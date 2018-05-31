using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Helpers;
using BookApi.Schema;
using BooksApiDbLib;
using BooksApiDbLib.Models;
using GraphQLCore.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        private IGraphQLSchema Schema { get; set; }
        private readonly ILogger _logger;
        public BookController(BookContext context, 
        ILogger<BookController> logger, IGraphQLSchema schema) : base(context)
        {
            this._logger = logger;
            this.Schema = schema;
        }

        [HttpPost("book")]
        public IActionResult PostBook([FromBody]Author book)
        {
            EntityResponse<Author> response = new EntityResponse<Author>();
            try
            {
                this.Entities.Books.Add(book);
                this.Entities.SaveChanges();
                response.SetEntity(book);
            }
            catch (System.Exception e)
            {
                response.AddError(e.Message);
            }
            return Ok(this.Entities.Authors);
        }
        [HttpPost("author")]
        public IActionResult PostAuthor([FromBody]Author author)
        {
            EntityResponse<Author> response = new EntityResponse<Author>();
            try
            {
                this.Entities.Authors.Add(author);
                this.Entities.SaveChanges();
                response.SetEntity(author);
            }
            catch (System.Exception e)
            {
                response.AddError(e.Message);
            }
            return Ok(this.Entities.Authors);
        }
        [HttpPost("graphql")]
        public JsonResult Post([FromBody] GraphiQLInput input)
        {
            return this.Json(this.Schema.Execute(input.Query, GetVariables(input), input.OperationName));
        }

        private static dynamic GetVariables(GraphiQLInput input)
        {
            var variables = input.Variables?.ToString();

            if (string.IsNullOrEmpty(variables))
                return new ExpandoObject();

            return JsonConvert.DeserializeObject<ExpandoObject>(variables);
        }
    }
}
