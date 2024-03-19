using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;

namespace StudyShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("SignIn")]
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            return await _authenticationService.LoginAsync(loginDto);
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<UserDto>> RegisterNewUser(CreateUserDto createUserDto)
        {
            UserDto newUser = await _authenticationService.RegisterNewUserAsync(createUserDto);
            return CreatedAtAction("GetUserById", "User", new { id = newUser.UserId }, newUser);
        }

    }
}