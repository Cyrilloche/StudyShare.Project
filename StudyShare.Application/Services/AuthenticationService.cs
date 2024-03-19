using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;
using StudyShare.Domain.Utilities;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IAuthenticationRepository _authenticationRepository;
        private IUserRepository _userRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository, IUserRepository userRepository)
        {
            _authenticationRepository = authenticationRepository;
            _userRepository = userRepository;
        }
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            User user = await _authenticationRepository.GetUserByEmailAsync(loginDto.UserEmail);

            if (user.UserPassword == loginDto.UserPassword)
                return ObjectUtilities.MapObject<UserDto>(user);
            return null;
        }
    }
}