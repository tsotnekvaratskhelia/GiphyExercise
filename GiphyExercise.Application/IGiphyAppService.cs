using GiphyExercise.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiphyExercise.Application
{
    public interface IGiphyAppService
    {
        Task<List<GifSearchResultDto>> Search(GifSearchDto search);
    }


}
