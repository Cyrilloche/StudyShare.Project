using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;

namespace StudyShare.Application.Interfaces
{
    public interface IKeywordService
    {
        Task<List<KeywordDto>> GetAllKeywordsAsync();
        Task<Keyword> AddKeywordAsync(KeywordDto keywordDto);
        Task DeleteKeywordAsync(int keywordId);
    }
}