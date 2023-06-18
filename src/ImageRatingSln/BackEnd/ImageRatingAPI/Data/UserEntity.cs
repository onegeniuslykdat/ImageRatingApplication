using ImageRatingModels;

namespace ImageRatingAPI.Data
{
    public class UserEntity : User
    {
        public DateTime DateCreated { get; set; }
    }
}
