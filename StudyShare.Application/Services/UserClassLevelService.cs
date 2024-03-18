using StudyShare.Application.Interfaces;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Interfaces;
using StudyShare.Application.Utilities;

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
            return DtosUtilities.ReturnIEnumerableDtosConverted<UserClassLevelDto, UserClassLevel>(userClassLevels).ToList();
        }

        public async Task<List<ClassLevelDto>> GetListOfClassByUserAsync(int userId)
        {
            List<ClassLevel> classLevels = await _userClassLevelRepository.GetListOfClassByUserAsync(userId);
            return DtosUtilities.ReturnIEnumerableDtosConverted<ClassLevelDto, ClassLevel>(classLevels).ToList();
        }
    }
}