using AdvertWebAPI_Restful.Models;

namespace AdvertWebAPI_Restful.Services
{
    public interface IUserService
    {
        public User GetUser(UserLogin userLogin);
    }
}
