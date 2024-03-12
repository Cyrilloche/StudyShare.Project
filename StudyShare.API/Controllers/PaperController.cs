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
            return await _paperSerice.GetAllPapers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaperDto>> GetPaperById(int id)
        {
            PaperDto paperDto = await _paperSerice.GetPaperById(id);
            if (paperDto != null)
                return paperDto;
            return BadRequest();
        }

        [HttpGet("authorId")]
        public async Task<ActionResult<List<PaperDto>>> GetPapersByAuthor(int authorId)
        {
            return await _paperSerice.GetPaperByAuthor(authorId);
        }


        [HttpPost]
        public async Task<ActionResult> CreatePaper(PaperDto paperDto)
        {
            if (paperDto != null)
                return Ok(await _paperSerice.CreatePaper(paperDto));
            return BadRequest();
        }

        [HttpPut]
        public async Task UpdatePaper(int paperId, UpdatePaperDto paperDto)
        {
            await _paperSerice.UpdatePaper(paperId, paperDto);
        }

        [HttpDelete]
        public async Task DeletePaper(int paperId)
        {
            await _paperSerice.DeletePaper(paperId);
        }


    }
}