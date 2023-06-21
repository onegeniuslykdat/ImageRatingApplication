using System;
using System.ComponentModel.DataAnnotations;

namespace ImageRatingModels
{
    public abstract class Image
    {
        [Key]
        public int ID { get; set; }
        // public int SourceID { get; set; }
        public string Description { get; set; }
        public string NameWithExt { get; set; } //= "";
        public string? ResourcePath { get; set; } //= "";
        public string? URL { get; set; } //= "";
    }
}