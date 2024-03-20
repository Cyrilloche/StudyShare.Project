using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;

namespace StudyShare.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task UpdateUserAsync(int id, UpdateUserDto user);
        Task DeleteUserAsync(int id);
    }
}