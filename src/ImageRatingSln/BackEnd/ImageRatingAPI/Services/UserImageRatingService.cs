using ImageRatingAPI.Data;
using ImageRatingAPI.DTOs;
using System.Collections.Generic;

namespace ImageRatingAPI.Services
{
    public class UserImageRatingService
    {
        private AppDbContext context { get; set; }

        public UserImageRatingService(AppDbContext _context)
        {
            context = _context;

        }

        // Always add Image Source *************************
        // Get Ratings
        public async Task<List<GetRatingsDTO>> Get()
        {
            List<UserImageRatingEntity> userimageratings = context.Set<UserImageRatingEntity>().ToList();

            return userimageratings.Select(i => new GetRatingsDTO()
            {
                ID = i.ID,
                ImageID = i.ImageID,
                UserID = i.UserID,
                Rating = i.Rating           
            }).ToList();
        }

        // Get Ratings by ID
        public async Task<GetRatingsDTO> GetRatingsByID(int id)
        {
            return (await Get()).FirstOrDefault(i => i.ID == id);
        }

        // Get Ratings by ImageID
        public async Task<List<GetRatingsDTO>> GetRatingsByImageID(int imageid)
        {
            return (await Get()).Where(i => i.ImageID == imageid).ToList();
        }

        // Get Ratings by UserID
        public async Task<List<GetRatingsDTO>> GetRatingsByUserID(GetUserImagesDTO user)
        {
            return (await Get()).Where(i => i.UserID == user.UserID).ToList();
        }

        // Get Images not rated
        public async Task<List<GetImageDTO>> GetImagesNotRated()
        {
            List<ImageEntity> images = context.Set<ImageEntity>().ToList();
            List<int> imagesRatedIDs = context.Set<UserImageRatingEntity>().Select(r => r.ImageID).ToList();

            List<GetImageDTO> result = new List<GetImageDTO>();

            foreach (ImageEntity i in images)
            {
                if(!imagesRatedIDs.Contains(i.ID))
                {
                    result.Add(new GetImageDTO
                    {
                        ID = i.ID,
                        ImageSourceID = i.ImageSourceEntityID,
                        NameWithExt = i.NameWithExt,
                        ResourcePath = i.ResourcePath,
                        URL = i.URL
                    });
                }
            }

            return result;
        }

        // Get Images not rated by UserID
        public async Task<List<GetImageDTO>> GetImagesNotRatedByUserID(GetUserImagesDTO user)
        {
            List<ImageEntity> images = context.Set<ImageEntity>().ToList();
            List<int> imagesRatedIDs = context.Set<UserImageRatingEntity>().Where(r => r.UserID == user.UserID).Select(r => r.ImageID).ToList();

            List<GetImageDTO> result = new List<GetImageDTO>();            

            foreach (ImageEntity i in images)
            {
                if (!imagesRatedIDs.Contains(i.ID))
                {
                    result.Add(new GetImageDTO
                    {
                        ID = i.ID,
                        ImageSourceID = i.ImageSourceEntityID,
                        NameWithExt = i.NameWithExt,
                        ResourcePath = i.ResourcePath,
                        URL = i.URL
                    });
                }
            }

            return result;
        }

        // Get Rating by User and Image IDs
        public async Task<GetRatingsDTO> GetRatingByImageIDAndUserID(GetUserAndImageRatingDTO userImageRating)
        {
            return (await Get()).FirstOrDefault(i => i.UserID == userImageRating.UserID && i.ImageID == userImageRating.ImageID);
        }

        // Get Images rated
        public async Task<List<GetImageDTO>> GetImagesRated()
        {
            List<ImageEntity> images = context.Set<ImageEntity>().ToList();
            List<int> imagesRatedIDs = context.Set<UserImageRatingEntity>().Select(r => r.ImageID).ToList();

            List<GetImageDTO> result = new List<GetImageDTO>();

            foreach (ImageEntity i in images)
            {
                if (imagesRatedIDs.Contains(i.ID))
                {
                    result.Add(new GetImageDTO
                    {
                        ID = i.ID,
                        ImageSourceID = i.ImageSourceEntityID,
                        NameWithExt = i.NameWithExt,
                        ResourcePath = i.ResourcePath,
                        URL = i.URL
                    });
                }
            }

            return result;
        }

        // Get Images rated by UserID
        public async Task<List<GetImageDTO>> GetImagesRatedByUserID(GetUserImagesDTO user)
        {
            List<ImageEntity> images = context.Set<ImageEntity>().ToList();
            List<int> imagesRatedIDs = context.Set<UserImageRatingEntity>().Where(r => r.UserID == user.UserID).Select(r => r.ImageID).ToList();

            List<GetImageDTO> result = new List<GetImageDTO>();

            foreach (ImageEntity i in images)
            {
                if (imagesRatedIDs.Contains(i.ID))
                {
                    result.Add(new GetImageDTO
                    {
                        ID = i.ID,
                        ImageSourceID = i.ImageSourceEntityID,
                        NameWithExt = i.NameWithExt,
                        ResourcePath = i.ResourcePath,
                        URL = i.URL
                    });
                }
            }

            return result;
        }

        // Create Rating
        public async Task<CreateRatingDTO> CreateRating(CreateRatingDTO newRating)
        {
            try
            {
                var n = context.Set<UserImageRatingEntity>().Add(new UserImageRatingEntity()
                {
                    ImageID = newRating.ImageID,
                    UserID = newRating.UserID,
                    Rating = newRating.Rating                    
                });

                context.SaveChanges();

                return newRating;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
