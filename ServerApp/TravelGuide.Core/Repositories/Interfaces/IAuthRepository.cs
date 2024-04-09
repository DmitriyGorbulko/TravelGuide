using TravelGuide.Db.Entity;

namespace TravelGuide.Core.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> SignUp(User user);
/*        Task<string> SignIn(string email, string password);*/
        Task<User?> GetUser(string email);
        Task<bool> IsUserExists(string email);

        /*Task<string> VeritifyJwt(string jwt);*/
    }
}
