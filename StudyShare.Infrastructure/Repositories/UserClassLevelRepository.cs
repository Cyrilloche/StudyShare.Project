using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Infrastructure.Repositories
{
    public class UserClassLevelRepository : IUserClassLevelRepository
    {
        private readonly StudyShareDbContext _context;
        public UserClassLevelRepository(StudyShareDbContext context)
        {
            _context = context;
        }

        public async Task AddClassLevelToUserAsync(int userId, int classLevelId)
        {
            UserClassLevel userClassLevel = new UserClassLevel
            {
                UserId = userId,
                ClassLevelId = classLevelId
            };
            _context.UserClassLevels.AddAsync(userClassLevel);

            await _context.SaveChangesAsync();
        }

        public async Task<List<UserClassLevel>> GetClassesByUserAsync(int userId)
        {
            List<UserClassLevel> userClassLevels = await _context.UserClassLevels.ToListAsync();

            List<UserClassLevel> resultList = userClassLevels.FindAll(u => u.UserId == userId);

            return resultList;
        }

        public async Task<List<ClassLevel>> GetListOfClassByUserAsync(int userId)
        {
            List<UserClassLevel> userClassLevels = await _context.UserClassLevels.ToListAsync();
            List<ClassLevel> listOfClasses = await _context.ClassLevels.ToListAsync();

            List<ClassLevel> listOfClassesToReturn = new List<ClassLevel>();

            IEnumerable<UserClassLevel> listByUser = userClassLevels.Where(list => list.UserId == userId);

            foreach (UserClassLevel classLevel in listByUser)
            {
                listOfClassesToReturn.AddRange(listOfClasses.Where(id => id.ClassLevelId == classLevel.ClassLevelId));
            }

            return listOfClassesToReturn;

            


            
        }
    }
}