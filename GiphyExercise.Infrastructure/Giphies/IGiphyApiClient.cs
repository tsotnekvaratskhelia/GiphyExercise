using GiphyExercise.Infrastructure.Giphies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyExercise.Infrastructure.Giphies
{
    public interface IGiphyApiClient
    {
        public Task<List<GIFImage>> GetGifImages(GIFSearch search);
    }
}
