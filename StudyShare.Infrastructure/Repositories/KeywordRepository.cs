using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Infrastructure.Repositories
{
    public class KeywordRepository : IKeywordRepository
    {
        private readonly StudyShareDbContext _context;
        public KeywordRepository(StudyShareDbContext context)
        {
            _context = context;
        }

        public async Task<Keyword> AddKeywordAsync(Keyword keyword)
        {
            await _context.Keywords.AddRangeAsync(keyword);
            await _context.SaveChangesAsync();

            return keyword;

        }

        public async Task DeleteKeywordAsync(int keywordId)
        {
            Keyword keyword = await _context.Keywords.FirstOrDefaultAsync(k => k.KeywordId == keywordId);
            if (keyword != null)
            {
                _context.Keywords.Remove(keyword);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Keyword>> GetAllKeywordsAsync()
        {
            return await _context.Keywords.ToListAsync();
        }
    }
}