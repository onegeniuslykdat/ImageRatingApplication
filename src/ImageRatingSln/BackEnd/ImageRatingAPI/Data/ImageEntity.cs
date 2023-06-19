using ImageRatingModels;

namespace ImageRatingAPI.Data
{
    public class ImageEntity : Image
    {
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int ImageSourceEntityID { get; set; }

        public ImageSourceEntity ImageSource { get; set; } = null;

        public ICollection<UserImageRatingEntity> ImageRatings { get; } = new List<UserImageRatingEntity>();
    }
}
