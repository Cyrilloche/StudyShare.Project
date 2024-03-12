using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig
{
    public class SchoolEntityTypeConfig : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(s => s.SchoolId);
            builder.Property(r => r.SchoolName).IsRequired().HasMaxLength(50);
            
        }
    }
}