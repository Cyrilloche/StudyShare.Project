using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Infrastructure.Repositories
{
    public class PaperKeywordRepository : IPaperKeywordRepository
    {
        private readonly StudyShareDbContext _context;
        public PaperKeywordRepository(StudyShareDbContext context)
        {
            _context = context;
        }
        public async Task AddKeywordsToPaperAsync(int paperId, List<int> keywordsId)
        {
            foreach (int keywordId in keywordsId)
            {
                PaperKeyword paperKeyword = new PaperKeyword
                {
                    PaperId = paperId,
                    KeywordId = keywordId
                };
                await _context.PaperKeywords.AddAsync(paperKeyword);
            };
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Keyword>> GetKeywordsByPaperAsync(int paperId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Paper>> GetPapersByKeywordsAsync(int keywordId)
        {
            throw new NotImplementedException();
        }

        // public async Task<IEnumerable<Keyword>> GetKeywordsByPaperAsync(int paperId)
        // {
        //     IEnumerable<PaperKeyword> keywords = _context.PaperKeywords.Where(kw => kw.PaperId == paperId).ToList();
        //     return null;

        // }

        // public async Task<IEnumerable<Paper>> GetPapersByKeywordsAsync(int keywordId)
        // {
        //     IEnumerable<Paper> papers = _context.PaperKeywords.Find(p => p.KeywordId == keywordId).ToList();
        //     return null;
        // }
    }
}