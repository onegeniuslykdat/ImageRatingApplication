﻿using System;

namespace ImageRatingModels
{
    public class UserImageRatings
    {
        public int ID { get; set; }
        public string UserID { get; set; } = ""; // Rating(1 - Like, 0 - Dislike)
        public string ImageID { get; set; } = "";
        public DateTime DateOfRating { get; set; } = DateTime.Now;
    }
}