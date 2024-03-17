using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Dtos;

namespace StudyShare.Application.Interfaces
{
    public interface IPaperKeywordService
    {
        Task<List<KeywordDto>> GetKeywordsByPaperAsync(int paperId);
        Task AddKeywordsToPaperAsync(int paperId, List<int> keywordsId);
        Task<List<PaperDto>> GetPapersByKeywordsAsync(int keywordId);
    }
}