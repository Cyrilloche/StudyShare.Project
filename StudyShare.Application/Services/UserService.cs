using StudyShare.Domain.Dtos;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;
using StudyShare.Domain.Utilities;
using StudyShare.Application.Exceptions;

namespace StudyShare.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(UserDto userDto)
        {
           if (userDto.UserPassword.Length < 8 
           ||!userDto.UserPassword.Any(char.IsDigit) 
           ||!userDto.UserPassword.Any(char.IsUpper) 
           ||!userDto.UserPassword.Any(char.IsLower))
            {
                throw new PasswordFormatException("Password does not meet format requirements");
            }
            return await _userRepository.CreateUser(ObjectUtilities.MapObject<User>(userDto));
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
                usersDto.Add(ObjectUtilities.MapObject<UserDto>(user));
           }

            return usersDto;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            Utilities.ServiceUtilities.InvalidIdVerification(id);
            User user = await _userRepository.GetUserById(id);
            
            return ObjectUtilities.MapObject<UserDto>(user);
        }

        public async Task UpdateUser(int id, UpdateUserDto userDto)
        {
            User user = await _userRepository.GetUserById(id);

            ObjectUtilities.UpdateObject<User, UpdateUserDto>(user, userDto);

            await _userRepository.UpdateUser(user);

        }

    }
}