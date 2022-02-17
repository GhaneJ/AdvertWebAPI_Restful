using AdvertWebAPI_Restful.Models;

namespace AdvertWebAPI_Restful.Repositories
{
    public class UserRepository
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
            new User(){Username="Stefan72h", EmailAddress="stefan.holmberg@systementor.se", GivenName="Stefan", Surname="Holmberg", Password="Hejsan123#",Role="Admin"},
            new User(){Username="ghane80j", EmailAddress="ghane80j@gmail.com", GivenName="Ghane", Surname="Jahanshahi", Password="Hejsan123#",Role="User"}
        };

    }
}
