using ImageRatingModels;

namespace ImageRatingAPI.Data
{
    public class UserImageRatingEntity : UserImageRatings
    {
        public DateTime DateCreated { get; set; }

        public UserEntity User { get; set; }
        public ImageEntity Image { get; set; }
    }
}
