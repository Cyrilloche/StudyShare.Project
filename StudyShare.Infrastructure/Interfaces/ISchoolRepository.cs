using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface ISchoolRepository
    {
        Task<List<School>> GetAllSchools();
        Task<School> GetSchoolById(int schoolId);
        Task<List<School>> GetSchoolByName(string schoolName);
        Task<School> CreateSchool(School school);
        Task DeleteSchool(int id);
        Task<School> UpdateSchool(int id, School school);
    }
}