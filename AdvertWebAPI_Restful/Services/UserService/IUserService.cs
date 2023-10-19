namespace AdvertWebAPI_Restful.Services;

using AdvertWebAPI_Restful.Models;

public interface IUserService
{
    public User GetUser(UserLogin userLogin);
    public IResult Login(UserLogin userLogin, IUserService userService, IConfiguration configuration);
}
