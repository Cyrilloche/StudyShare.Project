using Microsoft.EntityFrameworkCore;
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
                if (!_context.PaperKeywords.Any(pk => pk.PaperId == paperId && pk.KeywordId == keywordId))
                {
                    PaperKeyword paperKeyword = new PaperKeyword
                    {
                        PaperId = paperId,
                        KeywordId = keywordId
                    };
                    await _context.PaperKeywords.AddAsync(paperKeyword);
                }
            }
            await _context.SaveChangesAsync();
        }


        public async Task<List<Keyword>> GetKeywordsByPaperAsync(int paperId)
        {
            List<Keyword> keywords = await _context.PaperKeywords
                                    .Where(p => p.PaperId == paperId)
                                    .Select(s => s.Keyword)
                                    .ToListAsync();

            return keywords;
        }


        public async Task<List<Paper>> GetPapersByKeywordsAsync(int keywordId)
        {
            List<Paper> papers = await _context.PaperKeywords
                                .Where(k => k.KeywordId == keywordId)
                                .Select(s => s.Paper)
                                .ToListAsync();

            return papers;
        }
    }
}