using Microsoft.EntityFrameworkCore;
using Tunify.Data;

namespace Tunify
{
    public class Program
    {
       
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var ConnectionString = builder.Configuration.GetConnectionString("constr");

            builder.Services.AddDbContext<TunifyDbContext>(options =>
            options.UseSqlServer(ConnectionString));

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
