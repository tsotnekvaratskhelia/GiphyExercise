using GiphyExercise.Application.Models;
using GiphyExercise.Infrastructure.Giphies;
using GiphyExercise.Infrastructure.Giphies.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyExercise.Application
{
    public class GiphyAppService : IGiphyAppService
    {
        private readonly IGiphyApiClient _apiClient;

        public GiphyAppService(IGiphyApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<GifSearchResultDto>> Search(GifSearchDto search)
        {
            var responses = new List<GifSearchResultDto>();
            foreach (var term in search.Terms)
            {
                var response = await _apiClient.GetGifImages(new GIFSearch
                {
                    Term = term
                });

                var urls = response.Select(img => img.Url).ToList();
                responses.Add(new GifSearchResultDto
                {
                    Term = term,
                    Urls = urls
                });

            }

            return responses;
        }
    }


}
