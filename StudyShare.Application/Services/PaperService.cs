using StudyShare.Application.Interfaces;
using StudyShare.Domain.Utilities;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Interfaces;
using StudyShare.Application.Utilities;

namespace StudyShare.Application.Services
{
    public class PaperService : IPaperService
    {

        private readonly IPaperRepository _paperRepository;
        public PaperService(IPaperRepository paperRepository)
        {
            _paperRepository = paperRepository;
        }
        public async Task<Paper> CreatePaper(PaperDto paper)
        {
            return await _paperRepository.CreatePaper(ObjectUtilities.MapObject<Paper>(paper));
        }

        public async Task DeletePaper(int id)
        {
            await _paperRepository.DeletePaper(id);
        }

        public async Task<List<PaperDto>> GetAllPapers()
        {
            List<Paper> papers = await _paperRepository.GetAllPapers();
            return DtosUtilities.ReturnIEnumerableDtosConverted<PaperDto, Paper>(papers).ToList();
        }

        public async Task<List<PaperDto>> GetPaperByAuthor(int userId)
        {
            List<Paper> papers = await _paperRepository.GetPaperByAuthor(userId);
            return DtosUtilities.ReturnIEnumerableDtosConverted<PaperDto, Paper>(papers).ToList();
        }

        public async Task<PaperDto> GetPaperById(int id)
        {
            Paper paper = await _paperRepository.GetPaperById(id);
            return ObjectUtilities.MapObject<PaperDto>(paper);
        }

        public async Task UpdatePaper(int id, UpdatePaperDto paperDto)
        {
            Paper paper = await _paperRepository.GetPaperById(id);
            ObjectUtilities.UpdateObject<Paper, UpdatePaperDto>(paper, paperDto);

            await _paperRepository.UpdatePaper(paper);
        }
    }
}