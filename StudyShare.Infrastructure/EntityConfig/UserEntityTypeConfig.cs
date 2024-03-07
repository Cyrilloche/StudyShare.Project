using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig

{
    public class UserEntityTypeConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configure property 
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.UserLastname).IsRequired();
            builder.Property(u => u.UserFirstname).IsRequired();
            builder.Property(u => u.UserEmail).IsRequired();
            builder.Property(u => u.UserPassword).IsRequired();

            builder.HasData(
                new User { UserId = 1, UserLastname = "CHERRIER", UserFirstname = "Cyril", UserEmail = "cyril@gmail.com", UserPassword = "motdepasse" },
                new User { UserId = 2, UserLastname = "BRAHO", UserFirstname = "Leila", UserEmail = "leila@gmail.com", UserPassword = "motdepasse" }
            );

        }
    }
}