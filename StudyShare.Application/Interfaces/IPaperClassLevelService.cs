using StudyShare.Domain.Dtos;

namespace StudyShare.Application.Interfaces
{
    public interface IPaperClassLevelService
    {
        Task AddClassLevelToPaperAsync(List<int> classLevelIds, int paperId);
        Task<List<PaperDto>> GetPapersByClassLevelAsync(int classLevelId);
        Task<List<ClassLevelDto>> GetClassLevelsByPaperAsync(int paperId);
    }
}