using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;

namespace StudyShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaperController : ControllerBase
    {
        private IPaperService _paperSerice;
        public PaperController(IPaperService paperService)
        {
            _paperSerice = paperService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaperDto>>> GetAllPapers()
        {
            return await _paperSerice.GetAllPapersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaperDto>> GetPaperById(int id)
        {
            PaperDto paperDto = await _paperSerice.GetPaperByIdAsync(id);
            if (paperDto != null)
                return paperDto;
            return BadRequest();
        }


        [HttpGet("authorId")]
        public async Task<ActionResult<List<PaperDto>>> GetPapersByAuthor(int authorId)
        {
            return await _paperSerice.GetPaperByAuthorAsync(authorId);
        }


        [HttpPost]
        public async Task<ActionResult> CreatePaper(CreatePaperDto paperDto)
        {
            if (paperDto != null)
            {
                System.Console.WriteLine(paperDto.PaperName);
                System.Console.WriteLine(paperDto.PaperUploadDate);
                return Ok(await _paperSerice.CreatePaperAsync(paperDto));
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task UpdatePaper(int paperId, UpdatePaperDto paperDto)
        {
            await _paperSerice.UpdatePaperAsync(paperId, paperDto);
        }

        [HttpDelete]
        public async Task DeletePaper(int paperId)
        {
            await _paperSerice.DeletePaperAsync(paperId);
        }


    }
}