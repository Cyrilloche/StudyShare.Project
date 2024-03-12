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
            builder.Property(cl => cl.ClassLevelName).IsRequired().HasMaxLength(30);

            builder.HasData(
                new ClassLevel { ClassLevelId = 1, ClassLevelName = "CP" },
                new ClassLevel { ClassLevelId = 2, ClassLevelName = "CE1" },
                new ClassLevel { ClassLevelId = 3, ClassLevelName = "CE2" },
                new ClassLevel { ClassLevelId = 4, ClassLevelName = "CM1" },
                new ClassLevel { ClassLevelId = 5, ClassLevelName = "CM2" },
                new ClassLevel { ClassLevelId = 6, ClassLevelName = "6ème" },
                new ClassLevel { ClassLevelId = 7, ClassLevelName = "5ème" },
                new ClassLevel { ClassLevelId = 8, ClassLevelName = "4ème" },
                new ClassLevel { ClassLevelId = 9, ClassLevelName = "3ème" },
                new ClassLevel { ClassLevelId = 10, ClassLevelName = "2nde" },
                new ClassLevel { ClassLevelId = 11, ClassLevelName = "1ère" },
                new ClassLevel { ClassLevelId = 12, ClassLevelName = "Terminale" }
            );

        }
    }
}