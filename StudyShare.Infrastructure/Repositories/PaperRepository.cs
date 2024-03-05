using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Infrastructure.Repositories
{
    public class PaperRepository : IPaperRepository
    {

        private readonly StudyShareDbContext _context;

        public async Task<Paper> CreatePaper(Paper paper)
        {
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

        public async Task<Paper> UpdatePaper(int id, Paper currentPaper)
        {
            Paper paper = await GetPaperById(id);
            if (paper != null)
            {
                paper.PaperName = paper.PaperName;
                paper.PaperDescription = currentPaper.PaperDescription;
                paper.PaperKeyword = currentPaper.PaperKeyword;
                paper.PaperClassLevel = currentPaper.PaperClassLevel;
                paper.PaperVisibility = currentPaper.PaperVisibility;

                await _context.SaveChangesAsync();
                return paper;
            }

            return null;

        }
    }
}