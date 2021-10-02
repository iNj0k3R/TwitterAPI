using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using TwitterAPI.Contracts;

namespace TwitterAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TwitterController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        public TwitterController(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTweet(string id)
        {
            var bearerToken = _configuration["BearerToken"];
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", bearerToken);
            var posts =await  client.GetAsync($"https://api.twitter.com/2/tweets?ids={id}&tweet.fields=created_at&expansions=author_id&user.fields=created_at");
            var desPosts = JsonSerializer.Deserialize<Tweets>(await posts.Content.ReadAsStringAsync());
            return Ok(desPosts);
        }
    }
}
