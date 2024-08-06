using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify.Model;

namespace Tunify.Config
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Albums>
    {
        void IEntityTypeConfiguration<Albums>.Configure(EntityTypeBuilder<Albums> builder)
        {
            //Configure AlbumsID
            builder.HasKey(x => x.AlbumsID);
            builder.Property(x => x.AlbumsID).ValueGeneratedOnAdd().IsRequired();
            //builder.Property(x => x.UserID).HasColumnType("bigint");

            //Configure AlbumsName
            builder.Property(x => x.AlbumsName).HasMaxLength(50);
            builder.Property(x => x.AlbumsName).IsRequired();
            builder.Property(x => x.AlbumsName).HasColumnName("AlbumsName");

            //Configure Release Date
            builder.Property(x => x.ReleaseDate).HasColumnType("datetime");
        }
    }
}
