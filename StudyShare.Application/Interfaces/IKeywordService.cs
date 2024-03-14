using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;

namespace StudyShare.Application.Interfaces
{
    public interface IKeywordService
    {
        Task<List<KeywordDto>> GetAllKeywords();
        Task<Keyword> AddKeyword(KeywordDto keywordDto);
        Task DeleteKeyword(int keywordId);
    }
}