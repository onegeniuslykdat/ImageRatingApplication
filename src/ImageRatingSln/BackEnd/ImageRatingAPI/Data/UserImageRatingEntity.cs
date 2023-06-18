using ImageRatingModels;

namespace ImageRatingAPI.Data
{
    public class UserImageRatingEntity : UserImageRatings
    {
        public DateTime DateCreated { get; set; }
    }
}
