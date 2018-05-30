using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApiDbLib;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : BaseController
    {
        public BookController(BookContext context) : base(context)
        {
        }

        [HttpGet("authors")]
        public IActionResult GetAuthors()
        {
            return Ok(this.Entities.Authors);
        }

    }
}
