using System;

namespace ImageRatingModels
{
    public abstract class Image
    {
        public int ID { get; set; }
        public int SourceID { get; set; }
        public string BasePath { get; set; } //= "";
        public string ResourcePath { get; set; } //= "";
        public string URL { get; set; } //= "";
    }
}