using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig
{
    public class UserSchoolEntityTypeConfig : IEntityTypeConfiguration<UserSchool>
    {
        public void Configure(EntityTypeBuilder<UserSchool> builder)
        {
            // Make UserId & SchoolId as the primary key of the join table UserSchool
            builder.HasKey(us => new { us.UserId, us.SchoolId });

            // Create one to many relationship between User and UserSchool
            builder.HasOne<User>(us => us.User)
            .WithMany(u => u.UserSchool)
            .HasForeignKey(us => us.UserId);

            // Create one to many relationship between School and UserSchool
            builder.HasOne<School>(us => us.School)
            .WithMany(s => s.UserSchool)
            .HasForeignKey(us => us.SchoolId);

        }
    }
}