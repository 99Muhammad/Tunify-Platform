using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify.Model;

namespace Tunify.Config
{
    public class SongsConfiguration : IEntityTypeConfiguration<Songs>
    {
        void IEntityTypeConfiguration<Songs>.Configure(EntityTypeBuilder<Songs> builder)
        {
            //Configure SongsID
            builder.HasKey(x => x.SongID);
            builder.Property(x => x.SongID).ValueGeneratedOnAdd().IsRequired();
            //builder.Property(x => x.UserID).HasColumnType("bigint");

            //Configure Title
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasColumnName("Title");

            //Configure Genre 
            builder.Property(s => s.Genre).HasMaxLength(20);
            builder.Property(x => x.Genre).HasColumnName("Genre");

            builder.HasData(_LoaudSongInfo());
        }

        private static List<Songs> _LoaudSongInfo()
        {
            return new List<Songs>()
            {
                new Songs {SongID=1,  Title = "JohnDoe", Genre = "johndoe@example.com" },
                new Songs { SongID=2, Title = "Mark",    Genre =    "Mark@example.com" }
            };

        }
    }
}
