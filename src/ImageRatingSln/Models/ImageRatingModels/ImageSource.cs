using System;

namespace ImageRatingModels
{
    public class ImageSource
    {
        public int ID { get; set; }
        public string SourceName { get; set; } = ""; // SourceName(File System, External URL)
    }
}