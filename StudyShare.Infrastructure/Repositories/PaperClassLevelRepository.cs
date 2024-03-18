using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Infrastructure.Repositories
{
    public class PaperClassLevelRepository : IPaperClassLevelRepository
    {
        private readonly StudyShareDbContext _context;
        public PaperClassLevelRepository(StudyShareDbContext context)
        {
            _context = context;
        }
        public async Task AddClassLevelToPaperAsync(List<int> classLevelIds, int paperId)
        {
            foreach (int classLevelId in classLevelIds)
            {
                if (!await _context.PaperClassLevels.AnyAsync(pcl => pcl.ClassLevelId == classLevelId && pcl.PaperId == paperId))
                {
                    PaperClassLevel paperClassLevel = new PaperClassLevel
                    {
                        ClassLevelId = classLevelId,
                        PaperId = paperId
                    };
                    await _context.AddAsync(paperClassLevel);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClassLevel>> GetClassLevelsByPaperAsync(int paperId)
        {
            List<ClassLevel> classLevels = await _context.PaperClassLevels
                                            .Where(p => p.PaperId == paperId)
                                            .Select(cl => cl.ClassLevel)
                                            .ToListAsync();

            return classLevels;
        }

        public async Task<List<Paper>> GetPapersByClassLevelAsync(int classLevelId)
        {
            List<Paper> papers = await _context.PaperClassLevels
                                .Where(cl => cl.ClassLevelId == classLevelId)
                                .Select(p => p.Paper)
                                .ToListAsync();
            return papers;
        }
    }
}