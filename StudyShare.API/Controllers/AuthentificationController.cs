using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyShare.Application.Services;
using StudyShare.Domain.Dtos;

namespace StudyShare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentificationController : ControllerBase
    {
        private AuthenticationService _authentificationService;
        public AuthentificationController(AuthenticationService authentificationService)
        {
            _authentificationService = authentificationService;
        }

        [HttpPost]
        public async Task<UserDto> Login(LoginDto dataUser)
        {
            return await _authentificationService.Login(dataUser);
        }
    }
}