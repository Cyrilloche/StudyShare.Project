using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;

namespace StudyShare.Application.Interfaces
{
    public interface IPaperService
    {
        Task<Paper> CreatePaperAsync(CreatePaperDto paper);
        Task DeletePaperAsync(int id);
        Task<List<PaperDto>> GetAllPapersAsync();
        Task<List<PaperDto>> GetPaperByAuthorAsync(int userId);
        Task<PaperDto> GetPaperByIdAsync(int id);
        Task UpdatePaperAsync(int id, UpdatePaperDto paperDto);
    }
}