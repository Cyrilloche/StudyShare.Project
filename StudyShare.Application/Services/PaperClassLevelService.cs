using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Application.Interfaces;
using StudyShare.Application.Utilities;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Application.Services
{
    public class PaperClassLevelService : IPaperClassLevelService
    {
        private IPaperClassLevelRepository _paperClassLevelRepository;
        public PaperClassLevelService(IPaperClassLevelRepository paperClassLevelRepository)
        {
            _paperClassLevelRepository = paperClassLevelRepository;
        }

        public async Task AddClassLevelToPaperAsync(List<int> classLevelIds, int paperId)
        {
            await _paperClassLevelRepository.AddClassLevelToPaperAsync(classLevelIds, paperId);
        }

        public async Task<List<ClassLevelDto>> GetClassLevelsByPaperAsync(int paperId)
        {
            List<ClassLevel> classLevels = await _paperClassLevelRepository.GetClassLevelsByPaperAsync(paperId);

            return DtosUtilities.ReturnIEnumerableDtosConverted<ClassLevelDto, ClassLevel>(classLevels).ToList();
        }

        public async Task<List<PaperDto>> GetPapersByClassLevelAsync(int classLevelId)
        {
            List<Paper> papers = await _paperClassLevelRepository.GetPapersByClassLevelAsync(classLevelId);

            return DtosUtilities.ReturnIEnumerableDtosConverted<PaperDto, Paper>(papers).ToList();
        }
    }
}