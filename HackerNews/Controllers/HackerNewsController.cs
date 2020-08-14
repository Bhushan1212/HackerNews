using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
//using System.Text.Json;
using System.Threading.Tasks;
using HackerNews.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HackerNews.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {
        private readonly HttpClient client;

        public HackerNewsController()
        {
            this.client = new HttpClient();
        }

        [HttpGet]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 100)
        {
            try
            {
                var topNews = await client.GetStringAsync("https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty");

                var listOftopStories = JsonConvert.DeserializeObject<List<int>>(topNews);

                var topStories = listOftopStories.OrderBy(x => x).Skip((pageNumber - 1) * pageSize).Take(pageSize);

                return Ok(topStories);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest();

                var news = await client.GetStringAsync($"https://hacker-news.firebaseio.com/v0/item/{id}.json?print=pretty");

                var model = JsonConvert.DeserializeObject<StoryModel>(news);

                return Ok(model);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
