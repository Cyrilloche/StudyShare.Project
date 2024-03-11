using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Dtos;

namespace StudyShare.Application.Interfaces
{
    public interface IUserClassLevelService
    {
        Task<List<UserClassLevelDto>> GetClassesByUserAsync(int userId);
        Task AddClassLevelToUserAsync(int userId, int classLevelId);
        Task<List<ClassLevelDto>> GetListOfClassByUserAsync(int userId);
    }
}