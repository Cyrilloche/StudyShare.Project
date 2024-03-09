using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IPaperRepository
    {
        Task<Paper> CreatePaper(Paper paper);
        Task DeletePaper(int id);
        Task<List<Paper>> GetAllPapers();
        Task<List<Paper>> GetPaperByAuthor(int userId);
        Task<Paper> GetPaperById(int id);
        Task UpdatePaper(int id, Paper paper);
    }
}