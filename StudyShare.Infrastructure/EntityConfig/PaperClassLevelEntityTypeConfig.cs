using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig
{
    public class PaperClassLevelEntityTypeConfig : IEntityTypeConfiguration<PaperClassLevel>
    {
        public void Configure(EntityTypeBuilder<PaperClassLevel> builder)
        {
            builder.HasKey(pcl => new { pcl.PaperId, pcl.ClassLevelId });

            builder.HasOne<Paper>(pcl => pcl.Paper)
            .WithMany(p => p.PaperClassLevel)
            .HasForeignKey(pcl => pcl.PaperId);

            builder.HasOne<ClassLevel>(pcl => pcl.ClassLevel)
            .WithMany(cl => cl.PaperClassLevel)
            .HasForeignKey(pcl => pcl.ClassLevelId);
        }
    }
}