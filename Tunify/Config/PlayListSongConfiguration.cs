using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify.Model;

namespace Tunify.Config
{
    public class PlayListSongConfiguration : IEntityTypeConfiguration<PlayListSong>
    {
        void IEntityTypeConfiguration<PlayListSong>.Configure(EntityTypeBuilder<PlayListSong> builder)
        {
            //Configure PlayListSongID
            //builder.HasKey(x => x.PlayListSongID);
            //builder.Property(x => x.PlayListSongID).ValueGeneratedOnAdd().IsRequired();

            builder.HasKey(x => new { x.PlayListID, x.SongID });
            builder.HasOne(x => x.PlayList).WithMany(x => x.playListSong).
                HasForeignKey(x=>x.PlayListID);


          
            builder.HasOne(x => x.Songs).WithMany(x => x.playListSong).
            HasForeignKey(x => x.SongID);

            builder.HasData(
                new PlayListSong { PlayListID = 1, SongID = 1, PlayListSongID = 1 },
               new PlayListSong { PlayListID = 2, SongID = 1, PlayListSongID = 2 });

           // builder.Property(x => x.UserID).HasColumnType("bigint");
        }
    }
}
