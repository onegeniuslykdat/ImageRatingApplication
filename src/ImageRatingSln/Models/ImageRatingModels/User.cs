namespace ImageRatingModels
{
    public class User
    {
        public int ID { get; set; }

        public string Email { get; set; } = "";

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}