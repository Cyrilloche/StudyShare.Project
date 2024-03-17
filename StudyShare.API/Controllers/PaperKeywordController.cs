using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;

namespace StudyShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaperKeywordController : ControllerBase
    {
        private IPaperKeywordService _paperKeywordService;
        public PaperKeywordController(IPaperKeywordService paperKeywordService)
        {
            _paperKeywordService = paperKeywordService;
        }

        [HttpGet("KeywordsByPaper")]
        public async Task<ActionResult<List<KeywordDto>>> GetKeywordsByPaper(int paperId)
        {
            return await _paperKeywordService.GetKeywordsByPaperAsync(paperId);
        }

        [HttpGet("PaperByKeyword")]
        public async Task<ActionResult<List<PaperDto>>> GetPapersByKeywords(int keywordId)
        {
            return await _paperKeywordService.GetPapersByKeywordsAsync(keywordId);
        }

        [HttpPut]
        public async Task AddKeywordsToPaper(int paperId, List<int> keywordsId)
        {
            await _paperKeywordService.AddKeywordsToPaperAsync(paperId, keywordsId);
        }

    }
}