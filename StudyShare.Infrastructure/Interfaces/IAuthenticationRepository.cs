using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
