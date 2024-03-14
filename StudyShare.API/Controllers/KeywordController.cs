using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<KeywordDto>> GetAllKeywordAsync()
        {
            List<KeywordDto> keywordsDto = await _keywordService.GetAllKeywords();
            return Ok(keywordsDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddKeywordAsync(KeywordDto keywordDto)
        {
            if (keywordDto != null)
                return Ok(await _keywordService.AddKeyword(keywordDto));
            return BadRequest();
        }

        [HttpDelete]
        public async Task DeleteKeywordAsync(int keywordId)
        {
            await _keywordService.DeleteKeyword(keywordId);
        }

    }
}