using StudyShare.Domain.Entities;

namespace StudyShare.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task DeleteUserAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task UpdateUserAsync(User user);
    }
}