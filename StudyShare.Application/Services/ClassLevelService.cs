using StudyShare.Application.Interfaces;
using StudyShare.Application.Utilities;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Application.Services
{
    public class ClassLevelService : IClassLevelService
    {
        private IClassLevelRepository _classLevelRepository;
        public ClassLevelService(IClassLevelRepository classLevelRepository)
        {
            _classLevelRepository = classLevelRepository;
        }
        public async Task<List<ClassLevelDto>> GetAllClassLevel()
        {
            List<ClassLevel> classLevels = await _classLevelRepository.GetAllClassLevel();
            List<ClassLevelDto> classLevelDto = new List<ClassLevelDto>();

            foreach(ClassLevel classLevel in classLevels)
            {
                classLevelDto.Add(ObjectUtilities.MapObject<ClassLevelDto>(classLevel));
            }

            return classLevelDto;
        }

        public async Task<ClassLevelDto> GetClassLevelById(int classLevelId)
        {
            ClassLevel classLevel = await _classLevelRepository.GetClassLevelById(classLevelId);

            return ObjectUtilities.MapObject<ClassLevelDto>(classLevel);
        }
    }
}