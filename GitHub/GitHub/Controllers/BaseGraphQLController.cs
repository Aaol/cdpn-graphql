using GraphQL.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub.Controllers
{
    public abstract class BaseGraphQLController : Controller
    {
        protected GraphQLClient Client { get; set; }
        protected IOptions<ApiSettings> ApiSettings { get; set; }
        public BaseGraphQLController(IOptions<ApiSettings> options)
        {
            Client = new GraphQLClient(options.Value.Url);
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", options.Value.Token);
            Client.DefaultRequestHeaders.Add("User-Agent", "Aaol");
            this.ApiSettings = options;
        }

        protected string LoadQueryFromFile(string fileName)
        {
            return System.IO.File.ReadAllText(@"./Queries/" + fileName + ".graphql");
        }
    }
}
