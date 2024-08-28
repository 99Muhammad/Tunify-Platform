using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tunify.Config;

//using Tunify.m;
using Tunify.Model;

namespace Tunify.Data
{
    public class TunifyDbContext:IdentityDbContext<IdentityUser>
       
    {

        //public DbSet<AlbumConfiguration>AlbumConfiguration { get; set; }
        //public DbSet<Artists> Artists { get; set; }
        //public DbSet<PlayListConfiguration>PlayLists { get; set; }
        //public DbSet<Songs> Songs { get; set; }
        //public DbSet<PlayListSongs> PlayListSongs { get; set; }
        //public DbSet<Subscribtions> Subscribions { get; set; }
       
           

        public TunifyDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistsConfiguration());
            modelBuilder.ApplyConfiguration(new PlayListConfiguration());
            modelBuilder.ApplyConfiguration(new PlayListSongConfiguration());
            modelBuilder.ApplyConfiguration(new SongsConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TunifyDbContext).Assembly);

        }
        public DbSet<Tunify.Model.PlayList> PlayList { get; set; } = default!;
        public DbSet<Tunify.Model.User> Users { get; set; } = default!;
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Artists> Artists { get; set; }

        public DbSet<PlayListSong>PlayListSongs { get; set; }
    }
}
