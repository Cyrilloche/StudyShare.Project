using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IUserClassLevelRepository
    {
        Task<List<UserClassLevel>> GetClassesByUserAsync(int userId);
        Task AddClassLevelToUserAsync(int userId, int classLevelId);
        Task<List<ClassLevel>> GetListOfClassByUserAsync(int userId);
    }
}