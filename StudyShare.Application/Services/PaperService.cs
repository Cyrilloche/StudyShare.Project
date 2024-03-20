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
        public async Task<Paper> CreatePaperAsync(CreatePaperDto paper)
        {
            if (!PaperUtilities.IsValidName(paper.PaperName))
                throw new Exception("Invalid file name format");

            paper.PaperName = PaperUtilities.FormattingPaperName(paper.PaperName);

            return await _paperRepository.CreatePaperAsync(ObjectUtilities.MapObject<Paper>(paper));
        }

        public async Task DeletePaperAsync(int id)
        {
            await _paperRepository.DeletePaperAsync(id);
        }

        public async Task<List<PaperDto>> GetAllPapersAsync()
        {
            List<Paper> papers = await _paperRepository.GetAllPapersASync();
            return DtosUtilities.ReturnIEnumerableDtosConverted<PaperDto, Paper>(papers).ToList();
        }

        public async Task<List<PaperDto>> GetPaperByAuthorAsync(int userId)
        {
            List<Paper> papers = await _paperRepository.GetPaperByAuthorAsync(userId);
            return DtosUtilities.ReturnIEnumerableDtosConverted<PaperDto, Paper>(papers).ToList();
        }

        public async Task<PaperDto> GetPaperByIdAsync(int id)
        {
            Paper paper = await _paperRepository.GetPaperByIdAsync(id);
            return ObjectUtilities.MapObject<PaperDto>(paper);
        }

        public async Task UpdatePaperAsync(int id, UpdatePaperDto paperDto)
        {
            Paper paper = await _paperRepository.GetPaperByIdAsync(id);
            ObjectUtilities.UpdateObject<Paper, UpdatePaperDto>(paper, paperDto);

            await _paperRepository.UpdatePaperAsync(paper);
        }
    }
}