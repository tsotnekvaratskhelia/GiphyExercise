using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyExercise.Application.Models
{
    public class GifSearchResultDto
    {
        public string Term { get; set; }
        public List<string> Urls{ get; set; }
    }
}
