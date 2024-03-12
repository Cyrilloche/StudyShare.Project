using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.EntityConfig
{
    public class KeywordEntityTypeConfig : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder.HasKey(k => k.KeywordId);
            builder.Property(k => k.KeywordName).IsRequired();

            builder.HasData(
                // Fondamentaux
                new Keyword { KeywordId = 1, KeywordName = "Français"},
                new Keyword { KeywordId = 2, KeywordName = "Maths"},
                new Keyword { KeywordId = 3, KeywordName = "Histoire"},
                new Keyword { KeywordId = 4, KeywordName = "Géographie"},
                new Keyword { KeywordId = 5, KeywordName = "Anglais"},
                new Keyword { KeywordId = 6, KeywordName = "EPS"}, 
                new Keyword { KeywordId = 7, KeywordName = "Musique"},
                new Keyword { KeywordId = 8, KeywordName = "Arts"},
                new Keyword { KeywordId = 9, KeywordName = "Sciences"},
                // Secondaire
                new Keyword { KeywordId = 10, KeywordName = "Physique"},
                new Keyword { KeywordId = 11, KeywordName = "Chimie"},
                new Keyword { KeywordId = 12, KeywordName = "Biologie"},
                new Keyword { KeywordId = 13, KeywordName = "Philosophie"},
                new Keyword { KeywordId = 14, KeywordName = "Économie"},
                new Keyword { KeywordId = 15, KeywordName = "Sociologie"},
                new Keyword { KeywordId = 16, KeywordName = "Informatique"},
                new Keyword { KeywordId = 17, KeywordName = "Technologie"},
                // Langues supplémentaires
                new Keyword { KeywordId = 18, KeywordName = "Espagnol"},
                new Keyword { KeywordId = 19, KeywordName = "Allemand"},
                new Keyword { KeywordId = 20, KeywordName = "Italien"},
                new Keyword { KeywordId = 21, KeywordName = "Chinois"},
                new Keyword { KeywordId = 22, KeywordName = "Russe"},
                // Autres
                new Keyword { KeywordId = 23, KeywordName = "Latin"},
                new Keyword { KeywordId = 24, KeywordName = "Grec"},
                new Keyword { KeywordId = 25, KeywordName = "Éthique"},
                new Keyword { KeywordId = 26, KeywordName = "Civisme"} 
            );
        }
    }
}