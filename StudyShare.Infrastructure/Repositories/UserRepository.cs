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

        public UserRepository(StudyShareDbContext context)
        {
            _context = context;
        }

        private static List<User> _users = new()
        {
            new User { UserId = 1, UserFirstname = "Alex", UserLastname = "Dach" },
            new User { UserId = 2, UserFirstname = "Matthias", UserLastname = "Dumas" },
            new User { UserId = 3, UserFirstname = "Arnaud", UserLastname = "Muller" },
        };
        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            User user = await GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            if (_context == null)
                System.Console.WriteLine("NULL");
            System.Console.WriteLine("test");
            List<User> users = await _context.Users.ToListAsync();
            System.Console.WriteLine($"Number of users: {users.Count}");
            return users;
            //return _users.ToList();
        }


        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User> UpdateUser(int id, User updateUser)
        {
            User user = await GetUserById(id);

            if (user != null)
            {
                user.UserFirstname = updateUser.UserFirstname;
                user.UserLastname = updateUser.UserLastname;
                user.UserEmail = updateUser.UserEmail;
                user.UserPassword = updateUser.UserPassword;

                await _context.SaveChangesAsync();
                return user;

            }
            return null;

        }
    }
}