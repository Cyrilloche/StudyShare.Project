using StudyShare.Application.Interfaces;
using StudyShare.Domain.Utilities;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Application.Services
{
    public class UserClassLevelService : IUserClassLevelService
    {
        private IUserClassLevelRepository _userClassLevelRepository;
        public UserClassLevelService(IUserClassLevelRepository userClassLevelRepository)
        {
            _userClassLevelRepository = userClassLevelRepository;
        } 

        public async Task AddClassLevelToUserAsync(int userId, int classLevelId)
        {
            await _userClassLevelRepository.AddClassLevelToUserAsync(userId, classLevelId);
        }

        public async Task<List<UserClassLevelDto>> GetClassesByUserAsync(int userId)
        {
            List<UserClassLevel> userClassLevels = await _userClassLevelRepository.GetClassesByUserAsync(userId);
            List<UserClassLevelDto> userClassLevelDtos = new List<UserClassLevelDto>();

            foreach (UserClassLevel userClassLevel in userClassLevels)
            {
                userClassLevelDtos.Add(ObjectUtilities.MapObject<UserClassLevelDto>(userClassLevel));
                
            }

            return userClassLevelDtos;
        }

        public async Task<List<ClassLevelDto>> GetListOfClassByUserAsync(int userId)
        {
            List<ClassLevel> classLevels = await _userClassLevelRepository.GetListOfClassByUserAsync(userId);
            List<ClassLevelDto> classLevelDtos = new List<ClassLevelDto>();

            foreach (ClassLevel classLevel in classLevels)
            {
                classLevelDtos.Add(ObjectUtilities.MapObject<ClassLevelDto>(classLevel));
                
            } 

            return classLevelDtos;
        }
    }
}