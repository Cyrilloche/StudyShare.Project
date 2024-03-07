using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Database;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Infrastructure.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly StudyShareDbContext _context;
        public SchoolRepository(StudyShareDbContext context)
        {
            _context = context;
        }
        public async Task<School> CreateSchool(School school)
        {
            await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task DeleteSchool(int id)
        {
            School school = await GetSchoolById(id);
            if (school != null)
            {
                _context.Remove(school);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<School>> GetAllSchools()
        {
            return await _context.Schools.ToListAsync();
        }

        public async Task<School> GetSchoolById(int schoolId)
        {
            return await _context.Schools.FirstOrDefaultAsync(s => s.SchoolId == schoolId);
        }

        public async Task<List<School>> GetSchoolByName(string schoolName)
        {
            List<School> schools = await GetAllSchools();
            return schools.FindAll(s => s.SchoolName == schoolName);
        }

        public async Task UpdateSchool(int id, School updateSchool)
        {
            School school = await GetSchoolById(id);
            if (school != null)
            {
                school.SchoolName = updateSchool.SchoolName;
                await _context.SaveChangesAsync();
            }
        }
    }
}