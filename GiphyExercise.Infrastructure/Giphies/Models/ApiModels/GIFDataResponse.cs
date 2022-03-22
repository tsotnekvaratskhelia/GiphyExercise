using Newtonsoft.Json;

namespace GiphyExercise.Infrastructure.Giphies.Models.ApiModels
{
    internal class GIFDataResponse
    {
        [JsonProperty("images")]
        public Image Image { get; set; }
    }
}
