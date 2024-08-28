using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tunify.Data;
using Tunify.Model;
using Tunify.Repositories.Interfaces;
using Tunify.Repositories.Services;

namespace Tunify
{
    public class Program
    {

     
        public static void Main(string[] args)
        {

            /* var builder = WebApplication.CreateBuilder(args);


             builder.Services.AddControllers();

             var ConnectionString = builder.Configuration.GetConnectionString("constr");

             builder.Services.AddDbContext<TunifyDbContext>(options =>
             options.UseSqlServer(ConnectionString));


             //builder.Services.AddScoped<IPlayList, PlayListService>();

             builder.Services.AddScoped<IPlayList, PlayListService>();
             builder.Services.AddScoped<IUsers, UserService>();
             builder.Services.AddScoped<ISong, SongService>();
             builder.Services.AddScoped<IArtist, ArtistService>();

             var app = builder.Build();





             app.MapControllers();

             app.MapGet("/", () => "Hello World!");

             app.Run();*/

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TunifyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("constr")));


            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<TunifyDbContext>();
          

            builder.Services.AddControllers();
            builder.Services.AddScoped<IUsers, UserService>();
            builder.Services.AddScoped<ISong, SongService>();
            builder.Services.AddScoped<IArtist, ArtistService>();
            builder.Services.AddScoped<IPlayList, PlayListService>();
            builder.Services.AddScoped<IAccountUsers, IdentityUserService>();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
            });

            var app = builder.Build();
            
            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             }
                );

            
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });
            app.MapControllers();

            app.UseAuthentication();
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
