using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Application.Dtos;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;

namespace StudyShare.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            List<User> users = await _userRepository.GetAllUsers();

            List<UserDto> userDtos = new List<UserDto>();

            foreach (User user in users)
            {
                UserDto userDto = new UserDto(
                    user.UserId,
                    user.UserLastname,
                    user.UserFirstname,
                    user.UserEmail,
                    user.UserPassword
                );
                userDtos.Add(userDto);

            }

            return userDtos;
        }

        public Task<User> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}