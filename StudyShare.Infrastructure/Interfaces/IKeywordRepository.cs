using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.EntityConfig;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IKeywordRepository
    {
        Task<List<Keyword>> GetAllKeywords();
        Task<Keyword> AddKeyword(Keyword keyword);
        Task DeleteKeyWord(int keywordId);
    }
}