using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Application.Exceptions;
using StudyShare.Application.Interfaces;
using StudyShare.Application.Utilities;
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
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            User user = await _authenticationRepository.GetUserByEmailAsync(loginDto.UserEmail);

            if (user.UserPassword == loginDto.UserPassword)
                return ObjectUtilities.MapObject<UserDto>(user);
            return null;
        }

        public async Task<UserDto> RegisterNewUserAsync(CreateUserDto createUserDto)
        {
            User user = ObjectUtilities.MapObject<User>(createUserDto);

            if (ServiceUtilities.IsNull(user))
                throw new BadRequestException("Invalid datas");
            if (!ServiceUtilities.IsValidName(user.UserLastname))
                throw new BadRequestException("Invalid user lastname format");
            if (!ServiceUtilities.IsValidName(user.UserFirstname))
                throw new BadRequestException("Invalid user firstname format");
            if (!ServiceUtilities.IsValidEmail(user.UserEmail))
                throw new BadRequestException("Invalid user email format");
            if (!ServiceUtilities.IsValidPassword(user.UserPassword))
                throw new BadRequestException("Invalid user password format");

            user.UserPassword = HashUtilities.HashPassword(user.UserPassword);

            return ObjectUtilities.MapObject<UserDto>(user);


        }
    }
}