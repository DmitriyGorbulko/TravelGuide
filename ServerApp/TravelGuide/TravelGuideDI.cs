using TravelGuide.Repositories.Implements;
using TravelGuide.Repositories.Interfaces;
using TravelGuide.Services.Implements;
using TravelGuide.Services.Interfaces;

namespace TravelGuide
{
    public static class TravelGuideDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IAuthRepository, AuthRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services
                .AddScoped<IAuthService, AuthService>();
        }
    }
}
