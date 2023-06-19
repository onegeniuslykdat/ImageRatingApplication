namespace ImageRatingAPI.Business
{
    public class BusinessFunctionalities
    {
        /*
         * App checks if user already exists - Get User by email
         * if no, app registers user - Create User
         * if yes, app loads user's details - Get User by ID
         * App saves user's details into DI
         * All other pages/components reference this same user, if null, redirect back to Welcome Screen
         *
         *
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
