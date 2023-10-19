namespace AdvertWebAPI_Restful.Controllers;

using AdvertWebAPI_Restful.Services;
using Microsoft.AspNetCore.Mvc;

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    //public IResult GetUser(UserLogin user)
    //{
    //    _userService.GetUser(user);
    //    if (user == null)
    //    {
    //        return Results.NotFound("Användaren hittades ej!");
    //    }
    //    return Results.Ok(user);
    //}
    //[HttpGet("Login")]          //We use login to differentiate this HTTPGet method from another one
    //                            //Because there was an ambiguity to choose and it gave error response 500
    //public IResult Login(UserLogin user)
    //{
    //    _userService.Login(user, _userService, _configuration);

    //    if (user == null)
    //    {
    //        return Results.NotFound("Användaren hittades ej!");
    //    }
    //    return Results.Ok(user);
    //}
}
