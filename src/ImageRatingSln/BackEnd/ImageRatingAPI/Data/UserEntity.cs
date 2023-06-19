using ImageRatingModels;

namespace ImageRatingAPI.Data
{
    public class UserEntity : User
    {
        public DateTime DateCreated { get; set; }

        public ICollection<UserImageRatingEntity> ImageRatings { get; } = new List<UserImageRatingEntity>();
    }
}
