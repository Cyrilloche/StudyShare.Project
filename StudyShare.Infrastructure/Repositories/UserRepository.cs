using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;
using StudyShare.Infrastructure.Database;

namespace StudyShare.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StudyShareDbContext _context;

        public async Task<User> CreateUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            User user = await GetUserById(id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> UpdateUser(int id, User currentUser)
        {
            User user = await GetUserById(id);

            if (user != null)
            {
                user.UserFirstname = currentUser.UserFirstname;
                user.UserLastname = currentUser.UserLastname;
                user.UserEmail = currentUser.UserEmail;
                user.UserPassword = currentUser.UserPassword;

                await _context.SaveChangesAsync();
                return user;

            }
            return null;

        }
    }
}