using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Dtos;

namespace StudyShare.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UserDto> Login(LoginDto dataUser);
    }
}