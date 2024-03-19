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
                new Keyword { KeywordId = 1, KeywordName = "Lecture" },
                new Keyword { KeywordId = 2, KeywordName = "Écriture" },
                new Keyword { KeywordId = 3, KeywordName = "Grammaire" },
                new Keyword { KeywordId = 4, KeywordName = "Conjugaison" },
                new Keyword { KeywordId = 5, KeywordName = "Orthographe" },
                new Keyword { KeywordId = 6, KeywordName = "Vocabulaire" },
                new Keyword { KeywordId = 7, KeywordName = "Récit" },
                new Keyword { KeywordId = 8, KeywordName = "Poésie" },
                new Keyword { KeywordId = 9, KeywordName = "Résumé" },
                new Keyword { KeywordId = 10, KeywordName = "Dissertation" },

                new Keyword { KeywordId = 11, KeywordName = "Calcul" },
                new Keyword { KeywordId = 12, KeywordName = "Numération" },
                new Keyword { KeywordId = 13, KeywordName = "Géométrie" },
                new Keyword { KeywordId = 14, KeywordName = "Algèbre" },
                new Keyword { KeywordId = 15, KeywordName = "Proportionnalité" },
                new Keyword { KeywordId = 16, KeywordName = "Statistiques" },
                new Keyword { KeywordId = 17, KeywordName = "Probabilités" },
                new Keyword { KeywordId = 18, KeywordName = "Équations" },
                new Keyword { KeywordId = 19, KeywordName = "Inéquations" },
                new Keyword { KeywordId = 20, KeywordName = "Fonctions" },

                new Keyword { KeywordId = 21, KeywordName = "Préhistoire" },
                new Keyword { KeywordId = 22, KeywordName = "Antiquité" },
                new Keyword { KeywordId = 23, KeywordName = "Moyen Âge" },
                new Keyword { KeywordId = 24, KeywordName = "Renaissance" },
                new Keyword { KeywordId = 25, KeywordName = "Révolutions" },
                new Keyword { KeywordId = 26, KeywordName = "Guerres mondiales" },
                new Keyword { KeywordId = 27, KeywordName = "Décolonisation" },
                new Keyword { KeywordId = 28, KeywordName = "Histoire de France" },
                new Keyword { KeywordId = 29, KeywordName = "Histoire du monde" },
                new Keyword { KeywordId = 30, KeywordName = "Civilisations" },

                new Keyword { KeywordId = 31, KeywordName = "Cartographie" },
                new Keyword { KeywordId = 32, KeywordName = "Relief" },
                new Keyword { KeywordId = 33, KeywordName = "Climat" },
                new Keyword { KeywordId = 34, KeywordName = "Environnement" },
                new Keyword { KeywordId = 35, KeywordName = "Population" },
                new Keyword { KeywordId = 36, KeywordName = "Développement durable" },
                new Keyword { KeywordId = 37, KeywordName = "Mondialisation" },
                new Keyword { KeywordId = 38, KeywordName = "Géopolitique" },
                new Keyword { KeywordId = 39, KeywordName = "Ressources naturelles" },
                new Keyword { KeywordId = 40, KeywordName = "Aménagement du territoire" },

                new Keyword { KeywordId = 41, KeywordName = "Vocabulaire" },
                new Keyword { KeywordId = 42, KeywordName = "Grammaire" },
                new Keyword { KeywordId = 43, KeywordName = "Conjugaison" },
                new Keyword { KeywordId = 44, KeywordName = "Compréhension écrite" },
                new Keyword { KeywordId = 45, KeywordName = "Compréhension orale" },
                new Keyword { KeywordId = 46, KeywordName = "Expression écrite" },
                new Keyword { KeywordId = 47, KeywordName = "Expression orale" },
                new Keyword { KeywordId = 48, KeywordName = "Traduction" },
                new Keyword { KeywordId = 49, KeywordName = "Civilisation anglophone" },
                new Keyword { KeywordId = 50, KeywordName = "Langue des affaires" }

            );
        }
    }
}