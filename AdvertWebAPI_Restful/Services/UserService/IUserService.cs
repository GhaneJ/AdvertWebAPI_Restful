using AdvertWebAPI_Restful.Models;

namespace AdvertWebAPI_Restful.Services
{
    public interface IUserService
    {
        public User GetUser(UserLogin userLogin);
        public IResult Login(UserLogin userLogin, IUserService userService,IConfiguration configuration);
    }
}
