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

        public async Task DeleteUserAsync(int id)
        {
            User user = await GetUserByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task UpdateUserAsync(User updateUser)
        {
            _context.Users.Update(updateUser);
            await _context.SaveChangesAsync();
        }
    }
}