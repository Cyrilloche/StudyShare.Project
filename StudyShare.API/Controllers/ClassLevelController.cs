using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;

namespace StudyShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassLevelController : ControllerBase
    {

        private IClassLevelService _classLevelService;

        public ClassLevelController(IClassLevelService classLevelService)
        {
            _classLevelService = classLevelService;
        }

        [HttpGet]
        public async Task<List<ClassLevelDto>> GetAllClassLevel()
        {
            return await _classLevelService.GetAllClassLevel();
        }

        [HttpGet("{id}")]
        public async Task<ClassLevelDto> GetClassLevelById(int id)
        {
            return await _classLevelService.GetClassLevelById(id);
        }
    }
}