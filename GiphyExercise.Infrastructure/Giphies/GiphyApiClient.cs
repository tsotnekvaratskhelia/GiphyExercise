using GiphyExercise.Infrastructure.Giphies.Models;
using GiphyExercise.Infrastructure.Giphies.Models.ApiModels;
using GiphyExercise.Infrastructure.Giphies.Models.Mapper;
using GiphyExercise.Infrastructure.Giphies.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GiphyExercise.Infrastructure.Giphies
{
    public class GiphyApiClient : IGiphyApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly GiphyApiClientOption _apiClientOption;

        public GiphyApiClient(HttpClient httpClient, GiphyApiClientOption apiClientOption)
        {
            _httpClient = httpClient;
            _apiClientOption = apiClientOption;
        }

        public async Task<List<GIFImage>> GetGifImages(GIFSearch search)
        {
            if (search == null)
                throw new ArgumentNullException(nameof(search));

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["q"] = search.Term;
            query["api_key"] = _apiClientOption.APIKey;

            var uriBuilder = new UriBuilder(_apiClientOption.Search)
            {
                Query = query.ToString()
            };

            var response = await _httpClient.GetAsync(uriBuilder.ToString());
            var responseJson= await response.Content.ReadAsStringAsync();
            var gifResponses = JsonConvert.DeserializeObject<GIFResponseModel>(responseJson);
            return gifResponses.Map();
        }
    }
}
