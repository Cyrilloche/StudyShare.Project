using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IPaperKeywordRepository
    {
        Task<IEnumerable<Keyword>> GetKeywordsByPaperAsync(int paperId);
        Task AddKeywordsToPaperAsync(int paperId, List<int> keywordsId);
        Task<IEnumerable<Paper>> GetPapersByKeywordsAsync(int keywordId);
    }
}