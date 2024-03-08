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

            builder.HasData(
                new ClassLevel { ClassLevelId = 1, ClassLevelName = "CP"},
                new ClassLevel { ClassLevelId = 2, ClassLevelName = "CE1"},
                new ClassLevel { ClassLevelId = 3, ClassLevelName = "CE2"},
                new ClassLevel { ClassLevelId = 4, ClassLevelName = "CM1"},
                new ClassLevel { ClassLevelId = 5, ClassLevelName = "CM2"}
            );
        }
    }
}