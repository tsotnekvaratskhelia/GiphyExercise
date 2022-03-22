using GiphyExercise.Domain.Giphies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyExercise.Domain
{
    public interface IGiphyRepository
    {
        Task Save(Giphy giphy);
        Task<Giphy> Get(string term);
    }
}
