using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig
{
    public class PaperEntityTypeConfig : IEntityTypeConfiguration<Paper>
    {
        public void Configure(EntityTypeBuilder<Paper> builder)
        {
            builder.HasKey(p => p.PaperId);
            builder.Property(p => p.PaperName).IsRequired().HasMaxLength(255);
            builder.Property(p => p.PaperDescription).HasMaxLength(1000);
            builder.Property(p => p.PaperPath).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.PaperUploadDate).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PaperDownloadsNumber).IsRequired();
            builder.Property(p => p.PaperVisibility).IsRequired().HasDefaultValue(true);

            // Create one to many relationship between User and Paper
            builder.HasOne<User>(p => p.User)
            .WithMany(u => u.Paper)
            .HasForeignKey(p => p.UserId);


        }
    }
}