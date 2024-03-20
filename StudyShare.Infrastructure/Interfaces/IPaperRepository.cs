using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IPaperRepository
    {
        Task<Paper> CreatePaperAsync(Paper paper);
        Task DeletePaperAsync(int id);
        Task<List<Paper>> GetAllPapersASync();
        Task<List<Paper>> GetPaperByAuthorAsync(int userId);
        Task<Paper> GetPaperByIdAsync(int id);
        Task UpdatePaperAsync(Paper paper);
    }
}