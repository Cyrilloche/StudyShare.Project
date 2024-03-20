using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Infrastructure.Repositories
{
    public class PaperRepository : IPaperRepository
    {

        private readonly StudyShareDbContext _context;
        public PaperRepository(StudyShareDbContext context)
        {
            _context = context;
        }

        public async Task<Paper> CreatePaperAsync(Paper paper)
        {
            await _context.Papers.AddAsync(paper);
            await _context.SaveChangesAsync();
            return paper;
        }

        public async Task DeletePaperAsync(int id)
        {
            Paper paper = await GetPaperByIdAsync(id);
            if (paper != null)
            {
                _context.Papers.Remove(paper);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Paper>> GetAllPapersASync()
        {
            return await _context.Papers.ToListAsync();
        }

        public async Task<List<Paper>> GetPaperByAuthorAsync(int userId)
        {
            List<Paper> papers = await GetAllPapersASync();
            return papers.FindAll(u => u.UserId == userId);
        }

        public async Task<Paper> GetPaperByIdAsync(int id)
        {
            return await _context.Papers.FirstOrDefaultAsync(p => p.PaperId == id);
        }

        public async Task UpdatePaperAsync(Paper updatePaper)
        {
            _context.Papers.Update(updatePaper);
            await _context.SaveChangesAsync();
        }
    }
}