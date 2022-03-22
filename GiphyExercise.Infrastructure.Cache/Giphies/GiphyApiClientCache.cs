using GiphyExercise.Domain;
using GiphyExercise.Domain.Giphies;
using GiphyExercise.Infrastructure.Giphies;
using GiphyExercise.Infrastructure.Giphies.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiphyExercise.Infrastructure.Cache.Giphies
{
    public class GiphyApiClientCache : IGiphyApiClient
    {
        private readonly IGiphyApiClient _giphyApiClient;
        private readonly IGiphyRepository _giphyRepository;

        public GiphyApiClientCache(IGiphyApiClient giphyApiClient, IGiphyRepository giphyRepository)
        {
            _giphyApiClient = giphyApiClient;
            _giphyRepository = giphyRepository;
        }

        public async Task<List<GIFImage>> GetGifImages(GIFSearch search)
        {
            var cacheGiphy = await _giphyRepository.Get(search.Term);
            if (cacheGiphy !=  null)
            {
                return cacheGiphy.Urls.Select(img => new GIFImage
                {
                    Url = img
                }).ToList();
            }


            var apiGiphies = await _giphyApiClient.GetGifImages(search);
            var urls = apiGiphies.Select(x => x.Url).ToList();
            var giphy = new Giphy(urls, search.Term);
            await _giphyRepository.Save(giphy);
            return apiGiphies;
        }
    }
}
