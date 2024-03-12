using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;

namespace StudyShare.Application.Interfaces
{
    public interface IPaperService
    {
        Task<Paper> CreatePaper(PaperDto paper);
        Task DeletePaper(int id);
        Task<List<PaperDto>> GetAllPapers();
        Task<List<PaperDto>> GetPaperByAuthor(int userId);
        Task<PaperDto> GetPaperById(int id);
        Task UpdatePaper(int id, UpdatePaperDto paperDto);
    }
}