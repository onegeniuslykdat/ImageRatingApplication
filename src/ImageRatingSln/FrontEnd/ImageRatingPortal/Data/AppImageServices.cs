using ImageRatingModels;
using Newtonsoft.Json;

namespace ImageRatingPortal.Data
{
    public class AppImageServices
    {
        private readonly string baseUrl;
        private readonly IConfiguration config;

        public AppImageServices(IConfiguration _config)
        {
            config = _config;
            baseUrl = _config["ImageAPIConfiguration:BaseUrl"].ToString();
        }

        public async Task<AppImage> GetImageByID(int id)
        {
            string endpointUrl = config["ImageAPIConfiguration:GetByID"].ToString() + "?id=" + id.ToString();
            AppImage res = await APIRequestServices<AppImage>.Get(baseUrl, endpointUrl);

            return res;
        }
    }
}