using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> SignUp(User user);
        Task<User?> GetUser(string email);
        Task<bool> IsUserExists(string email);

        Task<User> GetById(int id);
    }
}
