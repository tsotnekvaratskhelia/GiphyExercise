using GiphyExercise.Application;
using GiphyExercise.Application.Models;
using GiphyExercise.Infrastructure.Giphies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GiphyExercise.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GiphiesController : ControllerBase
    {
        private readonly IGiphyAppService _giphyAppService;

        public GiphiesController(IGiphyAppService giphyAppService)
        {
            _giphyAppService = giphyAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GifSearchResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<List<GifSearchResultDto>> Search([FromQuery] GifSearchDto search)
        {
            return await _giphyAppService.Search(search);
        }
    }
}
