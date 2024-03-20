using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IUserSchoolRepository
    {
        Task<School> GetSchoolOfUserAsync(int userId);
    }
}