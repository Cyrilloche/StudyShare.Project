using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IKeywordRepository
    {
        Task<List<Keyword>> GetAllKeywords();
        Task<Keyword> AddKeyword(Keyword keyword);
        Task DeleteKeyWord(int keywordId);
    }
}