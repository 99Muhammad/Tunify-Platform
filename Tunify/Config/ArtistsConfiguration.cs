using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify.Model;
using Tunify.Repositories.Interfaces;

namespace Tunify.Config
{
    public class ArtistsConfiguration : IEntityTypeConfiguration<Artists>
    {
        void IEntityTypeConfiguration<Artists>.Configure(EntityTypeBuilder<Artists> builder)
        {
            //Configure ArtistsID
            builder.HasKey(x => x.ArtistsID);
            builder.Property(x => x.ArtistsID).ValueGeneratedOnAdd().IsRequired();
            //builder.Property(x => x.UserID).HasColumnType("bigint");

            //Configure Artists Name
            builder.Property(x => x.ArtistName).HasMaxLength(50);
            builder.Property(x => x.ArtistName).IsRequired();
            builder.Property(x => x.ArtistName).HasColumnName("ArtistName");

            //Configure Bio 
            builder.Property(x => x.Bio).HasColumnType("varchar(256)");
            builder.Property(x => x.Bio).IsRequired(false);
            builder.Property(x => x.Bio).HasColumnName("Bio");

            builder.HasData(LoadArtists());
           
        }

        private List<Artists> LoadArtists()
        {
            return new List<Artists> {

             new Artists { ArtistsID = 1, ArtistName = "Michael Jackson" , Bio =" good" },
             new Artists{ ArtistsID = 2, ArtistName = "Pink Floyd" , Bio =" good" },
             new Artists { ArtistsID = 3, ArtistName = "The Beatles" , Bio =" good" },

      };
        }
    }
}
