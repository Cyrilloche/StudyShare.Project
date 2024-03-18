using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IPaperClassLevelRepository
    {
        Task AddClassLevelToPaperAsync(List<int> classLevelIds, int paperId);
        Task<List<Paper>> GetPapersByClassLevelAsync(int classLevelId);
        Task<List<ClassLevel>> GetClassLevelsByPaperAsync(int paperId);
    }
}