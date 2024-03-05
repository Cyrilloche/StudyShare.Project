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
    public class KeywordRepository : IKeywordRepository
    {
        private readonly StudyShareDbContext _context;

        public async Task<Keyword> AddKeyword(Keyword keyword)
        {
            _context.Keywords.AddRangeAsync(keyword);
            await _context.SaveChangesAsync();

            return keyword;

        }

        public async Task DeleteKeyWord(int keywordId)
        {
            Keyword keyword = await _context.Keywords.FirstOrDefaultAsync(k => k.KeywordId == keywordId);
            if (keyword != null)
            {
                _context.Keywords.Remove(keyword);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Keyword>> GetAllKeywords()
        {
            return await _context.Keywords.ToListAsync();
        }
    }
}