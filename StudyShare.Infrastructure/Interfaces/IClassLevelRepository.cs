using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IClassLevelRepository
    {
        Task<List<ClassLevel>> GetAllClassLevelAsync();
        Task<ClassLevel> GetClassLevelByIdAsync(int classLevelId);
    }
}