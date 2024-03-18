using StudyShare.Application.Interfaces;
using StudyShare.Application.Utilities;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Application.Services
{
    public class PaperKeywordService : IPaperKeywordService
    {
        private IPaperKeywordRepository _paperKeywordRepository;
        public PaperKeywordService(IPaperKeywordRepository paperKeywordRepository)
        {
            _paperKeywordRepository = paperKeywordRepository;
        }

        public async Task AddKeywordsToPaperAsync(int paperId, List<int> keywordsId)
        {
            await _paperKeywordRepository.AddKeywordsToPaperAsync(paperId, keywordsId);
        }

        public async Task<List<KeywordDto>> GetKeywordsByPaperAsync(int paperId)
        {
            List<Keyword> keywords = await _paperKeywordRepository.GetKeywordsByPaperAsync(paperId);
            return DtosUtilities.ReturnIEnumerableDtosConverted<KeywordDto, Keyword>(keywords).ToList();
        }

        public async Task<List<PaperDto>> GetPapersByKeywordsAsync(int keywordId)
        {
            List<Paper> papers = await _paperKeywordRepository.GetPapersByKeywordsAsync(keywordId);

            return DtosUtilities.ReturnIEnumerableDtosConverted<PaperDto, Paper>(papers).ToList();
        }
    }
}