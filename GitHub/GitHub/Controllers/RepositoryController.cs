using GraphQL.Common.Request;
using GraphQL.Common.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHub.Controllers
{
    [Route("api/[controller]")]
    public class RepositoryController : BaseGraphQLController
    {
        public RepositoryController(IOptions<ApiSettings> options) : base(options)
        {
        }

        [HttpGet("repositories")]
        public async Task<IActionResult> GetUserRepositories()
        {
            try
            {
                GraphQLRequest request = new GraphQLRequest();
                request.Query = @"query{
                viewer {
                    name
                   repositories(last: 4) {
                        nodes {
                            name
                        }
                    }
                }
            }";
                GraphQLResponse response = await this.Client.PostAsync(request);
                return Ok(response.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
