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
            builder.Services.AddTransient<IPlayList, PlayListService>();
            builder.Services.AddTransient<IUsers, UserService>();
            builder.Services.AddTransient<ISong, SongService>();
            builder.Services.AddTransient<IArtist, ArtistService>();

            var app = builder.Build();






            app.MapControllers();
            
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
