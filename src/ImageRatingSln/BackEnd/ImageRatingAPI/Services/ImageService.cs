using ImageRatingAPI.Data;
using ImageRatingAPI.DTOs;

namespace ImageRatingAPI.Services
{
    public class ImageService
    {
        // Always add Image Source *************************
        // Get Images
        public async Task<List<GetUserDTO>> Get()
        {
            List<UserEntity> users = context.Set<UserEntity>().ToList();

            return users.Select(u => new GetUserDTO()
            {
                ID = u.ID,
                Email = u.Email
            }).ToList();
        }

        // Get Images by ID

        // Create Image Admin
        // Create ImageSource Admin
    }
}
