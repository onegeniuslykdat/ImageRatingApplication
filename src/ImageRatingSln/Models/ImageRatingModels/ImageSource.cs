using System;
using System.ComponentModel.DataAnnotations;

namespace ImageRatingModels
{
    public abstract class ImageSource
    {
        [Key]
        public int ID { get; set; }
        public string SourceName { get; set; } //= ""; // SourceName(File System, External URL)
    }
}