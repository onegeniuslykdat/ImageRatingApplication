using System;

namespace ImageRatingModels
{
    public abstract class UserImageRatings
    {
        public int ID { get; set; }
        public int UserID { get; set; }        
        public int ImageID { get; set; }        
        public int Rating { get; set; } // Rating(1 - Like, 0 - Dislike)
        // public DateTime DateOfRating { get; set; } = DateTime.Now;
    }
}