using ImageRatingAPI.Business;
using ImageRatingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ImageRatingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ImageController : ControllerBase
    {
        private readonly BusinessFunctionalities functionalities;

        public ImageController(BusinessFunctionalities _functionalities)
        {
            functionalities = _functionalities;
        }

        [HttpGet(Name = "GetImageByID")]
        public async Task<GetImageDTO> GetByID(int id)
        {
            return await functionalities.GetImageByID(id);
        }
    }
}