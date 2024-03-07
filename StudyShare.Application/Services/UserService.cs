using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudyShare.Domain.Dtos;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;
using StudyShare.Application.Utilities;

namespace StudyShare.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            await _userRepository.CreateUser(user);
            return user;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
            
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
           List<User> users = await _userRepository.GetAllUsers();

           List<UserDto> usersDto = new List<UserDto>();

           foreach (User user in users)
           {
                usersDto.Add(ObjectUtilities.ConvertToDTO<User, UserDto>(user));
           }

            return usersDto;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            User user = await _userRepository.GetUserById(id);
            
            return ObjectUtilities.ConvertToDTO<User, UserDto>(user);
        }

        public async Task UpdateUser(int id, UpdateUserDto userDto)
        {
            User user = await _userRepository.GetUserById(id);

            ObjectUtilities.ObjectUpdater<User, UpdateUserDto> (user, userDto);
        }

    }
}