using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Application.Interfaces;
using StudyShare.Application.Utilities;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Utilities;
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
            List<KeywordDto> keywordDtos = new List<KeywordDto>();

            foreach (Keyword keyword in keywords)
            {
                keywordDtos.Add(ObjectUtilities.MapObject<KeywordDto>(keyword));
            }

            return keywordDtos;
        }

        public async Task<List<PaperDto>> GetPapersByKeywordsAsync(int keywordId)
        {
            List<Paper> papers = await _paperKeywordRepository.GetPapersByKeywordsAsync(keywordId);

            return DtosUtilities.ReturnIEnumerableDtosConverted<PaperDto, Paper>(papers).ToList();
        }
    }
}