using Microsoft.AspNetCore.Mvc;
using StudyShare.Domain.Dtos;
using StudyShare.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            List<UserDto> users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            UserDto user = await _userService.GetUserById(id);
            if (user == null)
                throw new Exception();
            return Ok(user);
        }

        [HttpDelete]
        public async Task DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
        }

        [HttpPut]
        public async Task UpdateUser(int id, UpdateUserDto userDto)
        {
            await _userService.UpdateUser(id, userDto);
        }


    }
}
