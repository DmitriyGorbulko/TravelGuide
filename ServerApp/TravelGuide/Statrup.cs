using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TravelGuide.Api.Middlewares;
using TravelGuide.Db;
using TravelGuide.Models;
using TravelGuide.Models.Models;
using TravelGuide.Utilites;

namespace TravelGuide.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "TravelGuide.Api v1"); });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Default");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TravelGuideDbContext>((options) =>
                            options.UseNpgsql(_configuration.GetConnectionString("TravelGuideDb")));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Audience = AuthOptions.AUDIENCE;
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.KEY))
                };
            });
            services.AddAuthorization();


            services.AddCors(options =>
            {
                options.AddPolicy("Default",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost",
                "http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowedToAllowWildcardSubdomains();
                    });
            });
            services.AddHttpClient<AttractionClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8080"); // Укажите базовый URL для API
            });
            services.AddHttpClient<GuideClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8080");
            });
            services.AddHttpClient<TourClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8080");
            });


            // 👇 Configuring the Authorization Service
            services.AddControllers();

            services.AddRepositories();
            services.AddServices();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TravelGuide", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.OperationFilter<AuthorizationOperationFilter>();
            });
        }
    }
}
