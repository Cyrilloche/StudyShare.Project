using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig
{
    public class UserClassLevelEntityTypeConfig : IEntityTypeConfiguration<UserClassLevel>
    {
        public void Configure(EntityTypeBuilder<UserClassLevel> builder)
        {
            builder.HasKey(ucl => new { ucl.UserId, ucl.ClassLevelId });

            builder.HasOne<User>(ucl => ucl.User)
            .WithMany(u => u.UserClassLevel)
            .HasForeignKey(ucl => ucl.UserId);

            builder.HasOne<ClassLevel>(ucl => ucl.ClassLevel)
            .WithMany(cl => cl.UserClassLevel)
            .HasForeignKey(ucl => ucl.ClassLevelId);

        }
    }
}