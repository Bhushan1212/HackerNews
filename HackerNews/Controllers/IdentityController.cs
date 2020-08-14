using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackerNews.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        // GET: api/Identity
        [HttpGet]
        public async Task<string> Get()
        {
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                return string.Empty;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",

                Scope = "api1"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return string.Empty;
            }

           return tokenResponse.AccessToken;
            
        }
    }
}
