using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig
{
    public class UserWorkGroupEntityTypeConfig : IEntityTypeConfiguration<UserWorkGroup>
    {
        public void Configure(EntityTypeBuilder<UserWorkGroup> builder)
        {
            builder.HasKey(ug => new { ug.UserId, ug.WorkGroupId });

            builder.HasOne<User>(ug => ug.User)
            .WithMany(u => u.UserWorkGroup)
            .HasForeignKey(ug => ug.UserId);

            builder.HasOne<WorkGroup>(ug => ug.WorkGroup)
            .WithMany(g => g.UserWorkGroup)
            .HasForeignKey(ug => ug.WorkGroupId);
        }
    }
}