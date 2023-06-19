using ImageRatingAPI.DTOs;
using ImageRatingAPI.Services;

namespace ImageRatingAPI.Business
{
    public class BusinessFunctionalities
    {
        private UserService userService { get; set; }
        private ImageService imageService { get; set; }
        private UserImageRatingService userImageRatingService { get; set; }

        public BusinessFunctionalities(UserService _userService, ImageService _imageService, UserImageRatingService _userImageRatingService)
        {
            userService = _userService;
            imageService = _imageService;
            userImageRatingService = _userImageRatingService; 
        }
        /*
         * App checks if user already exists - Get User by email
         * if no, app registers user - Create User
         * if yes, app loads user's details - Get User by ID
         * App saves user's details into DI
         * All other pages/components reference this same user, if null, redirect back to Welcome Screen
         */
        public async Task<GetUserDTO> GetUserByEmail(GetUserDTO user)
        {
            try
            {
                var existingUser = await userService.GetUserByEmail(user.Email);
                return existingUser;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<GetUserDTO> GetUserByID(GetUserDTO user)
        {
            try
            {
                var existingUser = await userService.GetUserByID(user.ID);
                return existingUser;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<CreateUserDTO> CreateUser(CreateUserDTO newUser)
        {
            try
            {
                var user = await userService.CreateUser(newUser);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CreateUserDTO> CreateUserIfNew(CreateUserDTO user)
        {
            try
            {
                var possibleExistingUser = await userService.GetUserByEmail(user.Email);
                if(possibleExistingUser == null || string.IsNullOrWhiteSpace(possibleExistingUser.Email))
                {
                    CreateUserDTO newUser = await userService.CreateUser(user);                    
                }

                // Get user details by email
                var res = await GetUserByEmail(new GetUserDTO()
                {
                    Email = user.Email
                });

                return new CreateUserDTO()
                {
                    ID = res.ID,
                    Email = res.Email
                };
            }
            catch (Exception)
            {
                return null;
            }
        }





        /*
        * App checks if all images have been rated by the user - Get images NOT rated by user
        * if 0 or -1, app loads [Thank You Screen]
        * else, app sends the first randomized image - Get first image not rated by user
        * App checks if the user has rated any image - Get images rated by user
        * if false, app hides [Your History Button]
        * else, app shows the button
        * App creates new rating for the image by the user and re-renders this page - Create rating
        * * Pagination to reduce calls to API *
        * 
        * 
        * App checks if all images have been rated by the user - Get images NOT rated by user
        * if 0 or -1, app hides[New Image Button]
        * else, shows the button
        * App loads a list of all IDs of the images that the user has rated - Get list of IDs of images rated by user
        * App loads the image details based on the first ID - Get image and rating details by user and image ids
        * App loads thumbnails of all images based on the IDs as a grid. - Get image details by image id
        * 
        */
    }
}
