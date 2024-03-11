using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Utilities;
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

        public async Task<Paper> CreatePaper(Paper paper)
        {
            paper.PaperUploadDate = DateTime.Now;
            paper.PaperName = paper.PaperUploadDate.ToString("yyyyMMdd") + "_" + paper.PaperName;

            await _context.Papers.AddAsync(paper);
            await _context.SaveChangesAsync();
            return paper;
        }

        public async Task DeletePaper(int id)
        {
            Paper paper = await GetPaperById(id);
            if (paper != null)
            {
                _context.Papers.Remove(paper);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Paper>> GetAllPapers()
        {
            return await _context.Papers.ToListAsync();
        }

        public async Task<List<Paper>> GetPaperByAuthor(int userId)
        {
            List<Paper> papers = await GetAllPapers();
            return papers.FindAll(u => u.UserId == userId);
        }

        public async Task<Paper> GetPaperById(int id)
        {
            return await _context.Papers.FirstOrDefaultAsync(p => p.PaperId == id);
        }

        public async Task UpdatePaper(Paper updatePaper)
        {
            _context.Papers.Update(updatePaper);
            await _context.SaveChangesAsync();
        }
    }
}