using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyExercise.Domain.Giphies
{
    public class Giphy
    {
        public Giphy(List<string> urls, string term)
        {
            _urls = urls;
            Term = term;
        }

        private List<string> _urls;
        public string Term { get; private set; }
        public IReadOnlyCollection<string> Urls => _urls;
    }
}
