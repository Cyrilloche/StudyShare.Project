using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task RegisterNewUserAsync(User user);
        Task RegisterNewAdminAsync(User user);
    }
}