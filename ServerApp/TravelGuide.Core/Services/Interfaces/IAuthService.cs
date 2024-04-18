using TravelGuide.Db.Entity;
using TravelGuide.Models.Models;

namespace TravelGuide.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> SignUp(User user);
        Task<string> SignIn(UserRequest user);
        Task<User?> GetUser(string email);
        Task<bool> VerifyUser(string email, string password);
    }
}
