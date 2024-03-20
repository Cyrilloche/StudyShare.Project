using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IKeywordRepository
    {
        Task<List<Keyword>> GetAllKeywordsAsync();
        Task<Keyword> AddKeywordAsync(Keyword keyword);
        Task DeleteKeywordAsync(int keywordId);
    }
}