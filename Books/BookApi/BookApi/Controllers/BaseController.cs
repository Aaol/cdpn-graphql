using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApiDbLib;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    public abstract class BaseController : Controller
    {
       protected BookContext Entities {get; private set;}
       public BaseController(BookContext context)
       {
           this.Entities = context;
       }
    }
}
