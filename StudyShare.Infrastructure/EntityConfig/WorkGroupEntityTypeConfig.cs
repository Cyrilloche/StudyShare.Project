using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig

{
    public class WorkGroupEntityTypeConfig : IEntityTypeConfiguration<WorkGroup>
    {
        public void Configure(EntityTypeBuilder<WorkGroup> builder)
        {
            builder.HasKey(g => g.WorkGroupId);
            builder.Property(g => g.WorkGroupName).IsRequired();
        }
    }

}