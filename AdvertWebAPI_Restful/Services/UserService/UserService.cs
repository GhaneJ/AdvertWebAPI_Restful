using AdvertWebAPI_Restful.Models;
using AdvertWebAPI_Restful.Repositories;

namespace AdvertWebAPI_Restful.Services
{
    public class UserService : IUserService
    {
        public User GetUser(UserLogin userLogin)
        {
            User user = UserRepository.Users.FirstOrDefault(e =>e.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && e.Password.Equals(userLogin.Password));
            return user;
        }
    }
}
