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
            return await _context.Users.ToListAsync();
        }


        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task UpdateUser(int id, User updateUser)
        {
            User user = await GetUserById(id);

            if (user != null)
            {
                user.UserFirstname = updateUser.UserFirstname;
                user.UserLastname = updateUser.UserLastname;
                user.UserEmail = updateUser.UserEmail;
                user.UserPassword = updateUser.UserPassword;
                
                await _context.SaveChangesAsync();
            }
        }
    }
}