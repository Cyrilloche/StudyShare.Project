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
            builder.Property(u => u.UserLastname).IsRequired().HasMaxLength(30);
            builder.Property(u => u.UserFirstname).IsRequired().HasMaxLength(30);
            builder.Property(u => u.UserEmail).IsRequired().HasMaxLength(100);
            builder.Property(u => u.UserPassword).IsRequired().HasMaxLength(255);

            builder.HasData(
                new User { UserId = 1, UserLastname = "CHERRIER", UserFirstname = "Cyril", UserEmail = "cyril@gmail.com", UserPassword = "motdepasse" },
                new User { UserId = 2, UserLastname = "BRAHO", UserFirstname = "Leila", UserEmail = "leila@gmail.com", UserPassword = "motdepasse" }
            );

        }
    }
}