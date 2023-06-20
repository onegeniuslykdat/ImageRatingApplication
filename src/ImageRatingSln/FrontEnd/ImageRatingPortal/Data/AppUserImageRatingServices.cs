using ImageRatingModels;
using Newtonsoft.Json;

namespace ImageRatingPortal.Data
{
    public class AppUserImageRatingServices
    {
        private readonly string baseUrl;
        private readonly IConfiguration config;

        public AppUserImageRatingServices(IConfiguration _config)
        {
            config = _config;
            baseUrl = _config["UserImageRatingAPIConfiguration:BaseUrl"].ToString();
        }

        public async Task<AppUserImageRating> Create(AppUserImageRating userImageRating)
        {
            var rating = new
            {
                userID = userImageRating.UserID,
                imageID = userImageRating.ImageID,
                rating = userImageRating.Rating
            };

        string endpointUrl = config["UserAPIConfiguration:Create"].ToString();
            AppUserImageRating res = await APIRequestServices<AppUserImageRating>.Post(baseUrl, endpointUrl, JsonConvert.SerializeObject(rating));

            return res;
        }

        public async Task<int> GetImagesNotRatedByUser(AppUser user)
        {
            var requestUser = new
            {
                userId = user.ID
            };
            string endpointUrl = config["UserImageRatingAPIConfiguration:GetImagesNotRatedByUser"].ToString();
            int res = await APIRequestServices<int>.Post(baseUrl, endpointUrl, JsonConvert.SerializeObject(requestUser));

            return res;
        }

        public async Task<List<AppImage>> GetImagesRatedByUser(AppUser user)
        {
            var requestUser = new
            {
                userId = user.ID
            };
            string endpointUrl = config["UserImageRatingAPIConfiguration:GetImagesRatedByUser"].ToString();
            List<AppImage> res = await APIRequestServices<List<AppImage>>.Post(baseUrl, endpointUrl, JsonConvert.SerializeObject(requestUser));

            return res;
        }

        public async Task<bool> GetIfUserHasRatedAnyImage(AppUser user)
        {
            var requestUser = new
            {
                userId = user.ID
            };
            string endpointUrl = config["UserImageRatingAPIConfiguration:GetIfUserHasRatedAnyImage"].ToString();
            bool res = await APIRequestServices<bool>.Post(baseUrl, endpointUrl, JsonConvert.SerializeObject(requestUser));

            return res;
        }

        public async Task<AppUserImageRating> GetRatingByImageAndUserID(AppUserImageRating userRating)
        {
            var requestUserRating = new
            {
                userID = userRating.UserID,
                imageID = userRating.ImageID
            };
        string endpointUrl = config["UserImageRatingAPIConfiguration:GetRatingByImageAndUserID"].ToString();
            AppUserImageRating res = await APIRequestServices<AppUserImageRating>.Post(baseUrl, endpointUrl, JsonConvert.SerializeObject(requestUserRating));

            return res;
        }
    }
}