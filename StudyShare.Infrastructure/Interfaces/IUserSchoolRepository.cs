using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Entities;

namespace StudyShare.Infrastructure.Interfaces
{
    public interface IUserSchoolRepository
    {
        Task<School> GetSchoolOfUser(int userId);
    }
}