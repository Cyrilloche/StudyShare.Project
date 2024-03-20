using StudyShare.Application.Interfaces;
using StudyShare.Application.Utilities;
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
            if (keywordDto is null)
                throw new Exception("Keyword cannot be empty.");
            if (!KeywordUtilities.IsValidKeywordFormat(keywordDto.KeywordName))
                throw new Exception("Invalid keyword format.Keyword should contain only letters or digits, at least 2 caracters with a maximum length of 30 characters");


            keywordDto.KeywordName = KeywordUtilities.FormattingKeyword(keywordDto.KeywordName);

            return await _KeywordRepository.AddKeyword(ObjectUtilities.MapObject<Keyword>(keywordDto));
        }

        public async Task DeleteKeyword(int keywordId)
        {
            await _KeywordRepository.DeleteKeyword(keywordId);
        }

        public async Task<List<KeywordDto>> GetAllKeywords()
        {
            List<Keyword> keywords = await _KeywordRepository.GetAllKeywords();
            return DtosUtilities.ReturnIEnumerableDtosConverted<KeywordDto, Keyword>(keywords).ToList();
        }
    }
}