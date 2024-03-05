using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Database
{
    public class StudyShareDbContext : DbContext
    {

        public StudyShareDbContext(DbContextOptions<StudyShareDbContext> options) : base(options)
        {

        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(@"Server=.; Database=StudyShareDB; Trusted_Connection=True; Encrypt=False;");
        // }

        public DbSet<ClassLevel> ClassLevels { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkGroup> WorkGroups { get; set; }

        public DbSet<PaperClassLevel> PaperClassLevels { get; set; }
        public DbSet<PaperKeyword> PaperKeywords { get; set; }
        public DbSet<UserClassLevel> UserClassLevels { get; set; }
        public DbSet<UserSchool> UserSchools { get; set; }
        public DbSet<UserWorkGroup> UserWorkGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}