using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyExercise.Application.Models
{
    public class GifSearchDto
    {
        public List<string> Terms { get; set; } = new List<string>();
    }
}
