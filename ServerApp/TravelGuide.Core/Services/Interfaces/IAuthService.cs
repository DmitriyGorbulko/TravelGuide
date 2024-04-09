using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> SignUp(User user);
        Task<string> SignIn(string email, string password);
        Task<User?> GetUser(string email);
        Task<bool> VerifyUser(string email, string password);
    }
}
