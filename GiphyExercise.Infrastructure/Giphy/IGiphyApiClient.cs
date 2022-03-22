using GiphyExercise.Infrastructure.Giphy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyExercise.Infrastructure.Giphy
{
    public interface IGiphyApiClient
    {
        public Task<List<GIFImage>> GetGifImages(GIFSearch search);
    }
}
