using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Tunify.Model;

namespace Tunify.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Configure UserID
            builder.HasKey(x => x.UserID);
            builder.Property(x=>x.UserID).ValueGeneratedOnAdd().IsRequired();
            //builder.Property(x => x.UserID).HasColumnType("bigint");

            //Configure UserName
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x=>x.UserName).IsRequired();
            builder.Property(x => x.UserName).HasColumnName("UserName");

            //Configure Email 
            builder.Property(x => x.Email).HasColumnType("varchar(256)");
            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.Email).HasColumnName("Email");
            //Validate Email !
            builder.Property(x => x.Email).
                HasAnnotation("RegularExpression", @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

            //Configure Join Date
            builder.Property(x => x.Join_Date).HasColumnType("datetime");


            builder.HasData(_LoaudUserInfo());

        }
       

        private static List<User> _LoaudUserInfo()
        {
            return new List<User>()
            {
                new User {UserID=1,  UserName = "JohnDoe", Email = "johndoe@example.com", Join_Date = new DateTime(2010, 11, 21) },
                new User { UserID=2, UserName = "Mark", Email = "Mark@example.com", Join_Date = new DateTime(2013, 11, 21) }
            };
            
        }
    }
}
