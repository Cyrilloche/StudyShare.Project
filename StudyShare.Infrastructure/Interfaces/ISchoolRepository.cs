using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface ISchoolRepository
    {
        Task<List<School>> GetAllSchoolsAsync();
        Task<School> GetSchoolByIdAsync(int schoolId);
        Task<List<School>> GetSchoolByNameAsync(string schoolName);
        Task<School> CreateSchoolAsync(School school);
        Task DeleteSchoolAsync(int id);
        Task UpdateSchoolAsync(int id, School school);
    }
}