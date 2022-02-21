using AdvertWebAPI_Restful.Models;
using AdvertWebAPI_Restful.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdvertWebAPI_Restful.Services
{
    public class UserService : IUserService
    {
        public User GetUser(UserLogin userLogin)
        {
            User user = UserRepository.Users.FirstOrDefault(e =>e.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && e.Password.Equals(userLogin.Password));
            return user;
        }
        public IResult Login(UserLogin user, IUserService userService, IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                var loggedInUser = userService.GetUser(user);

                if (loggedInUser is null) return Results.NotFound("Användaren kan ej hittas!");

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
                    new Claim(ClaimTypes.Email, loggedInUser.EmailAddress),
                    new Claim(ClaimTypes.GivenName, loggedInUser.GivenName),
                    new Claim(ClaimTypes.Surname, loggedInUser.Surname),
                    new Claim(ClaimTypes.Role, loggedInUser.Role)
                };
                var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(10),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                        SecurityAlgorithms.HmacSha256)
                        );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Results.Ok(tokenString);
            }
            return Results.NotFound("token string hittades ej!");
        }
    }
}
