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
    public class AlbumsController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public AlbumsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        // GET api/albums
        [HttpGet]
        public async Task<ActionResult<List<Album>>> GetAllAlbums()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://jsonplaceholder.typicode.com/albums/");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                List<Album> albums = await response.Content.ReadAsAsync<List<Album>>();
                return Ok(albums);
            }

            return NotFound();
        }

        // GET api/albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbumsById(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://jsonplaceholder.typicode.com/albums/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Album album = await response.Content.ReadAsAsync<Album>();
                return Ok(album);
            }

            return NotFound();
        }
    }
}