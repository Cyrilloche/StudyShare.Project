using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;


namespace StudyShare.Infrastructure.EntityConfig
{
    public class ClassLevelEntityTypeConfig : IEntityTypeConfiguration<ClassLevel>
    {
        public void Configure(EntityTypeBuilder<ClassLevel> builder)
        {
            builder.HasKey(cl => cl.ClassLevelId);
            builder.Property(cl => cl.ClassLevelName).IsRequired();
        }
    }
}