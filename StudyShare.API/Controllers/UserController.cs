using Microsoft.AspNetCore.Mvc;
using StudyShare.Domain.Dtos;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudyShare.Application.Utilities;
using Microsoft.AspNetCore.Http.HttpResults;
using StudyShare.API.Utilities;

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
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            List<UserDto> users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            UserControllerUtilities.InvalidIdVerification(id);

            UserDto user = await _userService.GetUserById(id);
            if (user == null)
                throw new Exception();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDto user)
        {
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task DeleteUser(int id)
        {
            UserControllerUtilities.InvalidIdVerification(id);
            await _userService.DeleteUser(id);
        }

        [HttpPut]
        public async Task UpdateUser(int id, UpdateUserDto userDto)
        {
            UserControllerUtilities.InvalidIdVerification(id);
            await _userService.UpdateUser(id, userDto);
        }

        
    }
}
