using ImageRatingAPI.Data;
using ImageRatingAPI.DTOs;
using ImageRatingModels;
using System.Linq.Expressions;

namespace ImageRatingAPI.Services
{
    public class UserService
    {
        private AppDbContext context { get; set; }

        public UserService(AppDbContext _context)
        {
            context = _context;

        }        

        // Get User
        public async Task<List<GetUserDTO>> Get()
        {
            List<UserEntity> users = context.Set<UserEntity>().ToList();

            return users.Select(u => new GetUserDTO()
            {
                ID = u.ID,
                Email = u.Email
            }).ToList();
        }

        // Get User by Email
        public async Task<GetUserDTO> GetUserByEmail(string email)
        {

            return (await Get()).FirstOrDefault(u => u.Email == email);
        }

        // Get User by ID
        public async Task<GetUserDTO> GetUserByID(int id)
        {
            return (await Get()).FirstOrDefault(u => u.ID == id);
        }

        // Create User
        public async Task<CreateUserDTO> CreateUser(CreateUserDTO newUser)
        {
            try
            {
                var n = context.Set<UserEntity>().Add(new UserEntity()
                {
                    Email = newUser.Email
                });

                context.SaveChanges();

                return newUser;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
