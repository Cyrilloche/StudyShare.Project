using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;
using StudyShare.Domain.Repositories;
using StudyShare.Domain.Utilities;
using StudyShare.Infrastructure.Interfaces;
using StudyShare.Infrastructure.Repositories;

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

        public async Task<UserDto> Login(LoginDto dataUser)
        {
            User user = await _authenticationRepository.GetUserByEmailAsync(dataUser.UserEmail);

            if (dataUser.UserPassword == dataUser.UserPassword)
                return ObjectUtilities.MapObject<UserDto>(await _userRepository.GetUserById(user.UserId));

            return null;

        }
    }
}