using StudyShare.Domain.Dtos;

namespace StudyShare.Application.Interfaces
{
    public interface IClassLevelService
    {
        Task<List<ClassLevelDto>> GetAllClassLevelAsync();
        Task<ClassLevelDto> GetClassLevelByIdAsync(int classLevelId);
    }
}