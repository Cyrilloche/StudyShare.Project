using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Entities;

namespace StudyShare.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task DeleteUser(int id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task UpdateUser(int id, User user);
    }
}