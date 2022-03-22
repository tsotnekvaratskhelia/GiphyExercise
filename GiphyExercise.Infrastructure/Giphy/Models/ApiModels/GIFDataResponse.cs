using Newtonsoft.Json;

namespace GiphyExercise.Infrastructure.Giphy.Models.ApiModels
{
    internal class GIFDataResponse
    {
        [JsonProperty("images")]
        public Image Image { get; set; }
    }
}
