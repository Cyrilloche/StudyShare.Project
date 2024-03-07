using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Infrastructure.Repositories
{
    public class ClassLevelRepository : IClassLevelRepository
    {
        private readonly StudyShareDbContext _context;
        public ClassLevelRepository(StudyShareDbContext context)
        {
            _context = context;
        }
        public async Task<List<ClassLevel>> GetAllClassLevel()
        {
            return await _context.ClassLevels.ToListAsync();
        }
    }
}