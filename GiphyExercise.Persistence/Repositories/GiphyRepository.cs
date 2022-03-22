using GiphyExercise.Domain;
using GiphyExercise.Domain.Giphies;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyExercise.Persistence.Repositories
{
    public class GiphyRepository : IGiphyRepository
    {
        private readonly IDistributedCache _cache;

        public GiphyRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<Giphy> Get(string term)
        {
            var giphyJson = await _cache.GetStringAsync(term);
            if (string.IsNullOrWhiteSpace(giphyJson))
                return null;

            return JsonConvert.DeserializeObject<Giphy>(giphyJson);
        }

        public Task Save(Giphy giphy)
        {
            var giphyJson = JsonConvert.SerializeObject(giphy);
            return _cache.SetStringAsync(giphy.Term, giphyJson);
        }
    }
}
