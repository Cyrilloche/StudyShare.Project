using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;

namespace StudyShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordController : ControllerBase
    {
        private IKeywordService _keywordService;
        public KeywordController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        [HttpGet]
        public async Task<ActionResult<KeywordDto>> GetAllKeyword()
        {
            List<KeywordDto> keywordsDto = await _keywordService.GetAllKeywords();
            return Ok(keywordsDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddKeyword(KeywordDto keywordDto)
        {
            if (keywordDto != null)
                return Ok(await _keywordService.AddKeyword(keywordDto));
            return BadRequest();
        }

        [HttpDelete]
        public async Task DeleteKeyword(int keywordId)
        {
            await _keywordService.DeleteKeyword(keywordId);
        }

    }
}