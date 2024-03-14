using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Utilities;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Application.Services
{
    public class KeywordService : IKeywordService
    {
        private IKeywordRepository _KeywordRepository;
        public KeywordService(IKeywordRepository keywordRepository)
        {
            _KeywordRepository = keywordRepository;
        }
        public async Task<Keyword> AddKeyword(KeywordDto keywordDto)
        {
            return await _KeywordRepository.AddKeyword(ObjectUtilities.MapObject<Keyword>(keywordDto));
        }

        public async Task DeleteKeyword(int keywordId)
        {
            await _KeywordRepository.DeleteKeyword(keywordId);
        }

        public async Task<List<KeywordDto>> GetAllKeywords()
        {
            List<Keyword> keywords = await _KeywordRepository.GetAllKeywords();
            List<KeywordDto> keywordsDto = new List<KeywordDto>();

            foreach (Keyword keyword in keywords)
            {
                keywordsDto.Add(ObjectUtilities.MapObject<KeywordDto>(keyword));
            }

            return keywordsDto;
        }
    }
}