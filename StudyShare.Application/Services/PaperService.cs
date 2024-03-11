using StudyShare.Application.Interfaces;
using StudyShare.Domain.Utilities;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Interfaces;

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
            List<PaperDto> paperDtos = new List<PaperDto>();
            List<Paper> papers = await _paperRepository.GetAllPapers(); 

            foreach (Paper paper in papers)
            {
                paperDtos.Add(ObjectUtilities.MapObject<PaperDto>(paper));
            }

            return paperDtos;
        }

        public async Task<List<PaperDto>> GetPaperByAuthor(int userId)
        {
            List<Paper> papers = await _paperRepository.GetPaperByAuthor(userId);
            
            List<PaperDto> paperDtos = new List<PaperDto>(); 
            foreach (Paper paper in papers)
            {
                paperDtos.Add(ObjectUtilities.MapObject<PaperDto>(paper));
            }

            return paperDtos;
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