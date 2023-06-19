using System.ComponentModel.DataAnnotations;

namespace ImageRatingModels
{
    public abstract class User
    {
        [Key]
        public int ID { get; set; }

        public string Email { get; set; } //= "";

        // public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}