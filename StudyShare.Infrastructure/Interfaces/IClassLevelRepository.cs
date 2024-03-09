using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IClassLevelRepository
    {
        Task<List<ClassLevel>> GetAllClassLevel();
        Task<ClassLevel> GetClassLevelById(int classLevelId);
    }
}