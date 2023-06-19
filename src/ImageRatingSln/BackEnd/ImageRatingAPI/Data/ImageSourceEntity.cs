using ImageRatingModels;
using Microsoft.Extensions.Hosting;

namespace ImageRatingAPI.Data
{
    public class ImageSourceEntity : ImageSource
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public ICollection<ImageEntity> Images { get; } = new List<ImageEntity>();
    }
}
