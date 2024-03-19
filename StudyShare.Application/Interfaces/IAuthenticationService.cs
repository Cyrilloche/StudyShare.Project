using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;

namespace StudyShare.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterNewUserAsync(CreateUserDto createUserDto);
    }
}