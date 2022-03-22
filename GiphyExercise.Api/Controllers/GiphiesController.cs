using GiphyExercise.Infrastructure.Giphy;
using GiphyExercise.Infrastructure.Giphy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyExercise.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GiphiesController : ControllerBase
    {
        private readonly IGiphyApiClient _giphyApiClient;

        public GiphiesController(IGiphyApiClient giphyApiClient)
        {
            _giphyApiClient = giphyApiClient;
        }

        [HttpGet]
        public async Task<List<GIFImage>> Search([FromQuery]GIFSearch search)
        {
            return await _giphyApiClient.GetGifImages(search);
        }
    }
}
