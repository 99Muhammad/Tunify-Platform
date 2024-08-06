using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify.Model;

namespace Tunify.Config
{
    public class PlayListConfiguration : IEntityTypeConfiguration<PlayList>
    {
        void IEntityTypeConfiguration<PlayList>.Configure(EntityTypeBuilder<PlayList> builder)
        {
            //Configure PlayListID
            builder.HasKey(x => x.PlayListID);
            builder.Property(x => x.PlayListID).ValueGeneratedOnAdd().IsRequired();
            //builder.Property(x => x.UserID).HasColumnType("bigint");

            //Configure PlayList Name
            builder.Property(x => x.PlayListName ).HasMaxLength(50);
            builder.Property(x => x.PlayListName).IsRequired();
            builder.Property(x => x.PlayListName).HasColumnName("PlayListName");


            //Configure CreatedDate
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");


            builder.HasData(_LoaudPlayListInfo());
        }

        private static List<PlayList> _LoaudPlayListInfo()
        {
            return new List<PlayList>()
            {
                new PlayList { PlayListID=1, PlayListName = "HowYourLife",CreatedDate = new DateTime(2021,11,10) },
                new PlayList { PlayListID=2, PlayListName = "FunG", CreatedDate = new DateTime(2019,11,10) }
            };

        }
    }
}
