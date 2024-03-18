using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;

namespace StudyShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaperClassLevelController : ControllerBase
    {
        private IPaperClassLevelService _paperClassLevelService;
        public PaperClassLevelController(IPaperClassLevelService paperClassLevelService)
        {
            _paperClassLevelService = paperClassLevelService;
        }

        [HttpGet("ClassLevelByPaper")]
        public async Task<ActionResult<List<ClassLevelDto>>> GetClassLevelsByPaper(int paperId)
        {
            return await _paperClassLevelService.GetClassLevelsByPaperAsync(paperId);
        }

        [HttpGet("PaperByClassLevel")]
        public async Task<ActionResult<List<PaperDto>>> GetPapersByClassLevel(int classLevelId)
        {
            return await _paperClassLevelService.GetPapersByClassLevelAsync(classLevelId);
        }

        [HttpPut]
        public async Task AddClassLeveltoPaper(List<int> classLevelIds, int paperId)
        {
            await _paperClassLevelService.AddClassLevelToPaperAsync(classLevelIds, paperId);
        }
    }

}