using TravelGuide.Repositories.Implements;
using TravelGuide.Repositories.Interfaces;

namespace TravelGuide
{
    public static class TravelGuideDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
