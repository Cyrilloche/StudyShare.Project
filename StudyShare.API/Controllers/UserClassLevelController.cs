using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;

namespace StudyShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserClassLevelController : ControllerBase
    {
        private IUserClassLevelService _userClassLevelService;
        public UserClassLevelController(IUserClassLevelService userClassLevelService)
        {
            _userClassLevelService = userClassLevelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserClassLevelDto>>> GetClassesByUser(int id)
        {
            return await _userClassLevelService.GetClassesByUserAsync(id);
        }

        [HttpGet("ClassesByUser")]
        public async Task<ActionResult<List<ClassLevelDto>>> GetListOfClassByUser(int userId)
        {
            return await _userClassLevelService.GetListOfClassByUserAsync(userId);
        }

        [HttpPut]
        public async Task AddClassLevelToUser(int userId, int classLevelId)
        {
            await _userClassLevelService.AddClassLevelToUserAsync(userId, classLevelId);
        }
    }
}