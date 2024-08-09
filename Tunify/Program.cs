using Microsoft.EntityFrameworkCore;
using Tunify.Data;
using Tunify.Repositories.Interfaces;
using Tunify.Repositories.Services;

namespace Tunify
{
    public class Program
    {

     
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
           
            
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

            app.Run();
        }
    }
}
