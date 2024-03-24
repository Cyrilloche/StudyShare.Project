using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;

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

        [HttpPost]
        public async Task AddKeywordsToPaper(int paperId, List<int> keywordsId)
        {
            await _paperKeywordService.AddKeywordsToPaperAsync(paperId, keywordsId);
        }

    }
}