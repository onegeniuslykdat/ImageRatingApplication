using System;

namespace ImageRatingModels
{
    public abstract class ImageSource
    {
        public int ID { get; set; }
        public string SourceName { get; set; } //= ""; // SourceName(File System, External URL)
    }
}