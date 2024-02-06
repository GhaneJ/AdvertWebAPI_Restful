namespace AdvertWebAPI_Restful.Repositories;

using AdvertWebAPI_Restful.Models;

public class UserRepository
{
    public static List<User> Users { get; set; } = new List<User>()
    {
        new User(){Username="stefan72h",
            EmailAddress="stefan.holmberg@systementor.se",
            GivenName="Stefan", Surname="Holmberg",
            Password="Hejsan123#",Role="Admin"},
        new User(){Username="ghane80j",
            EmailAddress="ghane80j@gmail.com",
            GivenName="Ghane", Surname="Jahanshahi",
            Password="Hejsan123#",Role="User"}
    };
}
