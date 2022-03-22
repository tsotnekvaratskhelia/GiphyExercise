using GiphyExercise.Infrastructure.Giphy.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiphyExercise.Infrastructure.Giphy.Models.Mapper
{
    internal static class GIFImageMapper
    {
        internal static List<GIFImage> Map(this GIFResponseModel gIFResponse)
        {
            if (gIFResponse == null)
                return new List<GIFImage>();

            return gIFResponse.Data.Select(img => new GIFImage
            {
                Url = img.Image.Original.Url
            }).ToList();
        }
    }
}
