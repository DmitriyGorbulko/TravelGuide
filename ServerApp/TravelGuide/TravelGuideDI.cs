using TravelGuide.Core.Repositories.Implements;
using TravelGuide.Core.Repositories.Interfaces;
using TravelGuide.Core.Services.Implements;
using TravelGuide.Core.Services.Interfaces;

namespace TravelGuide.Api
{
    public static class TravelGuideDI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IAuthRepository, AuthRepository>()
                .AddScoped<IPointRepository, PointRepository>()
                .AddScoped<IWayRepository, WayRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IPointService, PointService>()
                .AddScoped<IWayService, WayService>();
        }
    }
}
