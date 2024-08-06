using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tunify.Model;

namespace Tunify.Config
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            //Configure SubscriptionID
            builder.HasKey(x => x.SubscriptionID);
            builder.Property(x => x.SubscriptionID).ValueGeneratedOnAdd().IsRequired();
            //builder.Property(x => x.UserID).HasColumnType("bigint");

            //Configure Subscription Type
            builder.Property(x => x.SubscriptionType).HasMaxLength(50);
            builder.Property(x => x.SubscriptionType).IsRequired();
            builder.Property(x => x.SubscriptionType).HasColumnName("SubscriptionType");

            //Configure Price 
            builder.Property(x => x.Price).HasColumnType("decimal");
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.Price).HasColumnName("Price");
            

        }
    }
}
