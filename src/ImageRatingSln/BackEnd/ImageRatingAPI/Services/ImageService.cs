using ImageRatingAPI.Data;
using ImageRatingAPI.DTOs;

namespace ImageRatingAPI.Services
{
    public class ImageService
    {
        private AppDbContext context { get; set; }

        public ImageService(AppDbContext _context)
        {
            context = _context;

        }

        // Always add Image Source *************************
        // Get Images
        public async Task<List<GetImageDTO>> Get()
        {
            List<ImageEntity> images = context.Set<ImageEntity>().ToList();

            return images.Select(i => new GetImageDTO()
            {
                ID = i.ID,
                NameWithExt = i.NameWithExt,
                ResourcePath = i.ResourcePath,
                ImageSourceID = i.ImageSourceEntityID,
                URL = i.URL
            }).ToList();
        }

        // Get Images by ID
        public async Task<GetImageDTO> GetImageByID(int id)
        {
            return (await Get()).FirstOrDefault(i => i.ID == id);
        }

        // Create Image Admin
        // Create ImageSource Admin
    }
}
