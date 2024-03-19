using StudyShare.Domain.Entities;

namespace StudyShare.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task DeleteUser(int id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task UpdateUser(User user);
    }
}