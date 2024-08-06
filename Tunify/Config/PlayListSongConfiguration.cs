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
            builder.HasKey(x => x.PlayListSongID);
            builder.Property(x => x.PlayListSongID).ValueGeneratedOnAdd().IsRequired();
            //builder.Property(x => x.UserID).HasColumnType("bigint");
        }
    }
}
