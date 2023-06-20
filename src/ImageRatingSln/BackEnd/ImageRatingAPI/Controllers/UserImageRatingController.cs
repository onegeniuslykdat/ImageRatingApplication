using ImageRatingAPI.Business;
using ImageRatingAPI.DTOs;
using ImageRatingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace ImageRatingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserImageRatingController : ControllerBase
    {
        private readonly BusinessFunctionalities functionalities;

        public UserImageRatingController(BusinessFunctionalities _functionalities)
        {
            functionalities = _functionalities;
        }

        [HttpPost(Name = "GetRatingByImageAndUserID")]
        public async Task<GetRatingsDTO> GetRatingByImageAndUserID(GetUserAndImageRatingDTO userImageRating)
        {
            return await functionalities.GetRatingByImageAndUserID(userImageRating);
        }

        [HttpPost(Name = "GetIfUserHasRatedAnyImage")]
        public async Task<bool> GetIfUserHasRatedAnyImage(GetUserImagesDTO user)
        {
            return await functionalities.GetIfUserHasRatedAnyImage(user);
        }

        [HttpPost(Name = "GetImagesRatedByUser")]
        public async Task<List<GetImageDTO>> GetImagesRatedByUser(GetUserImagesDTO user)
        {
            return await functionalities.GetImagesRatedByUser(user);
        }

        [HttpPost(Name = "GetRandomImageNotRatedByUser")]
        public async Task<int> GetRandomImageNotRatedByUser(GetUserImagesDTO user)
        {
                return await functionalities.GetImagesNotRatedByUser(user);            
        }

        [HttpPost(Name = "CreateRating")]
        public async Task<CreateRatingDTO> CreateRating(CreateRatingDTO newRating)
        {
            return await functionalities.CreateRating(newRating);               
        }
    }
}