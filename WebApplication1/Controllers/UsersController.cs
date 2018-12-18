using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public UsersController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://jsonplaceholder.typicode.com/users/");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                List<User> users = await response.Content.ReadAsAsync<List<User>>();
                return Ok(users);
            }

            return NotFound();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://jsonplaceholder.typicode.com/users/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                User user = await response.Content.ReadAsAsync<User>();
                return Ok(user);
            }

            return NotFound();
        }

        // GET api/users/5/albums
        [HttpGet("{id}/albums")]
        public async Task<ActionResult<List<Album>>> GetUserAlbumById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://jsonplaceholder.typicode.com/users/{id}/albums");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                List<Album> albums = await response.Content.ReadAsAsync<List<Album>>();
                return Ok(albums);
            }

            return NotFound();
        }
    }
}
