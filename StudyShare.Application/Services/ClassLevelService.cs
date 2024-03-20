using StudyShare.Application.Interfaces;
using StudyShare.Domain.Utilities;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Interfaces;
using StudyShare.Application.Utilities;

namespace StudyShare.Application.Services
{
    public class ClassLevelService : IClassLevelService
    {
        private IClassLevelRepository _classLevelRepository;
        public ClassLevelService(IClassLevelRepository classLevelRepository)
        {
            _classLevelRepository = classLevelRepository;
        }
        public async Task<List<ClassLevelDto>> GetAllClassLevelAsync()
        {
            List<ClassLevel> classLevels = await _classLevelRepository.GetAllClassLevelAsync();
            return DtosUtilities.ReturnIEnumerableDtosConverted<ClassLevelDto, ClassLevel>(classLevels).ToList();
        }

        public async Task<ClassLevelDto> GetClassLevelByIdAsync(int classLevelId)
        {
            ClassLevel classLevel = await _classLevelRepository.GetClassLevelByIdAsync(classLevelId);

            return ObjectUtilities.MapObject<ClassLevelDto>(classLevel);
        }
    }
}