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
                .AddScoped<IFavoriteTagRepository, FavoriteTagRepository>()
                .AddScoped<IPlaceRepository,PlaceRepository>()
                .AddScoped<IPointOfWayRepository, PointOfWayRepository>()
                .AddScoped<IReviewRepository, ReviewRepository>()
                .AddScoped<ITagOfPlaceRepository, TagOfPlaceRepository>()
                .AddScoped<ITagRepository, TagRepository>()
                .AddScoped<ITypePlaceRepository, TypePlaceRepository>()
                .AddScoped<IWayRepository, WayRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            return services
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IPlaceService, PlaceService>()
                .AddScoped<IPointOfWayService, PointOfWayService>()
                .AddScoped<ITypePlaceService, TypePlaceService>()
                .AddScoped<IWayService, WayService>();
        }
    }
}
