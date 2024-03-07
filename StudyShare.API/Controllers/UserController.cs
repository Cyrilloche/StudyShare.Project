using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Dtos;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }
    }
}
