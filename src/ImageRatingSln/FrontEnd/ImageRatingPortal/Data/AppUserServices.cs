using ImageRatingModels;
using Newtonsoft.Json;

namespace ImageRatingPortal.Data
{
    public class AppUserServices
    {
        private readonly string baseUrl;
        private readonly IConfiguration config;

        public AppUserServices(IConfiguration _config)
        {
            config = _config;
            baseUrl = _config["UserAPIConfiguration:BaseUrl"].ToString();
        }

        public async Task<AppUser> CreateUserIfNew(AppUser user)
        {
            var userToCheck = new
            {
                ID = user.ID,
                Email = user.Email
            };

            string endpointUrl = config["UserAPIConfiguration:Create"].ToString();
            AppUser res = await APIRequestServices<AppUser>.Post(baseUrl, endpointUrl, JsonConvert.SerializeObject(userToCheck));

            return res;
        }

        public async Task<AppUser> GetUserByID(AppUser user)
        {
            var userToCheck = new
            {
                ID = user.ID,
                Email = user.Email
            };

            string endpointUrl = config["UserAPIConfiguration:GetByID"].ToString();
            AppUser res = await APIRequestServices<AppUser>.Post(baseUrl, endpointUrl, JsonConvert.SerializeObject(userToCheck));

            return res;
        }
    }
}