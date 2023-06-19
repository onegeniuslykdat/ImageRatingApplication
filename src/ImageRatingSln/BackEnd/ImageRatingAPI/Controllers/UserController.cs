using ImageRatingAPI.Business;
using ImageRatingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ImageRatingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly BusinessFunctionalities functionalities;

        public UserController(BusinessFunctionalities _functionalities)
        {
            functionalities = _functionalities;
        }

        [HttpPost(Name = "GetUserByEmail")]
        public async Task<GetUserDTO> GetByEmail(GetUserDTO user)
        {
            return await functionalities.GetUserByEmail(user);
        }

        [HttpPost(Name = "GetUserByID")]
        public async Task<GetUserDTO> GetByID(GetUserDTO user)
        {
            return await functionalities.GetUserByID(user);
        }

        [HttpPost(Name = "CreateUserIfNew")]
        public async Task<CreateUserDTO> CreateIfNew(CreateUserDTO user)
        {
            return await functionalities.CreateUserIfNew(user);
        }
    }
}