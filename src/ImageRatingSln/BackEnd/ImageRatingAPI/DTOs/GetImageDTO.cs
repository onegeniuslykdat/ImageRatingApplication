using ImageRatingModels;

namespace ImageRatingAPI.DTOs
{
    public class GetImageDTO : Image
    {
        public int ImageSourceID { get; set; }
    }
}
