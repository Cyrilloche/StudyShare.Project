using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig
{
    public class PaperKeywordEntityTypeConfig : IEntityTypeConfiguration<PaperKeyword>
    {
        public void Configure(EntityTypeBuilder<PaperKeyword> builder)
        {
            builder.HasKey(pk => new { pk.PaperId, pk.KeywordId });

            builder.HasOne<Paper>(pk => pk.Paper)
            .WithMany(p => p.PaperKeyword)
            .HasForeignKey(pk => pk.PaperId);

            builder.HasOne<Keyword>(pk => pk.Keyword)
            .WithMany(k => k.PaperKeyword)
            .HasForeignKey(pk => pk.KeywordId);
        }
    }
}