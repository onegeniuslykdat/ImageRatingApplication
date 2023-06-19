using ImageRatingModels;

namespace ImageRatingAPI.DTOs
{
    public class GetUserAndImageRatingDTO
    {
        public int UserID { get; set; }

        public int ImageID { get; set; }
    }
}
