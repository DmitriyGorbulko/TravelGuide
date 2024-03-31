using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TravelGuide;
using TravelGuide.Middlewares;

internal class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(builder =>
            {
                builder.AddJsonFile("appsettings.json", true);
                builder.AddJsonFile("appsettings.Development.json", true);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel(serverOptions =>
                {
                    long gb5 = 5L * 1024L * 1024L * 1024L;
                    serverOptions.Limits.MaxRequestBodySize = gb5;
                    serverOptions.Limits.MaxRequestBufferSize = gb5;
                });
            });


}