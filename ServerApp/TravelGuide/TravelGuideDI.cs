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
                .AddScoped<IWayRepository, WayRepository>()
                .AddScoped<IPlaceRepository,PlaceRepository>()
                .AddScoped<IPointOfWayRepository, PointOfWayRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IWayService, WayService>()
                .AddScoped<IPlaceService, PlaceService>()
                .AddScoped<IPointOfWayService, PointOfWayService>();
        }
    }
}
