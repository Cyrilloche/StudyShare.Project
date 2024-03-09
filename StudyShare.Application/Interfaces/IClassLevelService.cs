using StudyShare.Domain.Dtos;

namespace StudyShare.Application.Interfaces
{
    public interface IClassLevelService
    {
        Task<List<ClassLevelDto>> GetAllClassLevel();
        Task<ClassLevelDto> GetClassLevelById(int classLevelId);
    }
}