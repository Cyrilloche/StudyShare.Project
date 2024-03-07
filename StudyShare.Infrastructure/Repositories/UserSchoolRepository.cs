using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Infrastructure.Repositories
{
    public class UserSchoolRepository : IUserSchoolRepository
    {
        private readonly StudyShareDbContext _context;
        public async Task<School?> GetSchoolOfUser(int userId)
        {
            var userSchool = await _context.UserSchools.FirstOrDefaultAsync(school => school.UserId == userId);
            var school = await _context.Schools.FirstOrDefaultAsync(school => school.SchoolId == userSchool.SchoolId);

            return school;
        }
    }
}