using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration _configuration;
        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            UserDto userDto = await _authenticationService.LoginAsync(loginDto);
            string token = CreateToken(userDto);
            return Ok(token);
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<UserDto>> RegisterNewUser(CreateUserDto createUserDto)
        {
            UserDto newUser = await _authenticationService.RegisterNewUserAsync(createUserDto);
            return CreatedAtAction("GetUserById", "User", new { id = newUser.UserId }, newUser);
        }

        [HttpPost("SignUpAdmin")]
        public async Task<ActionResult<UserDto>> RegisterNewAdmin(CreateUserDto createUserDto)
        {
            UserDto newAdmin = await _authenticationService.RegisterNewAdminAsync(createUserDto);
            return CreatedAtAction("GetUserById", "User", new { id = newAdmin.UserId }, newAdmin);
        }

        private string CreateToken(UserDto user)
        {
            var userRole = user.UserRoleId == 1 ? "Admin" : "User";
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UserEmail),
                new Claim(ClaimTypes.Role, userRole)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

    }
}