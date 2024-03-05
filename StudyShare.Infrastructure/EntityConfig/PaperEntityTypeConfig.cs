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
            builder.Property(p => p.PaperName).IsRequired();
            builder.Property(p => p.PaperDescription);
            builder.Property(p => p.PaperPath).IsRequired();
            builder.Property(p => p.PaperAuthor).IsRequired();
            builder.Property(p => p.PaperUploadDate).IsRequired();
            builder.Property(p => p.PaperDownloadsNumber).IsRequired();
            builder.Property(p => p.PaperVisibility).IsRequired();

            // Create one to many relationship between User and Paper
            builder.HasOne<User>(p => p.User)
            .WithMany(u => u.Paper)
            .HasForeignKey(p => p.PaperId);


        }
    }
}