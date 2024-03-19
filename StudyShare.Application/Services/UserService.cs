using StudyShare.Domain.Dtos;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;
using StudyShare.Domain.Utilities;
using StudyShare.Application.Exceptions;
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

        public async Task DeleteUser(int id)
        {
            if (!ServiceUtilities.IsValidId(id))
                throw new BadRequestException("Invalid id");
            await _userRepository.DeleteUser(id);

        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            List<User> users = await _userRepository.GetAllUsers();
            return DtosUtilities.ReturnIEnumerableDtosConverted<UserDto, User>(users).ToList();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            if (!ServiceUtilities.IsValidId(id))
                throw new BadRequestException("Invalid id");

            return ObjectUtilities.MapObject<UserDto>(await _userRepository.GetUserById(id));
        }

        public async Task UpdateUser(int id, UpdateUserDto userDto)
        {
            if (!ServiceUtilities.IsValidId(id))
                throw new BadRequestException("Invalid id");

            if (userDto.UserFirstname != null)
                if (!ServiceUtilities.IsValidName(userDto.UserFirstname))
                    throw new BadRequestException("Invalid user firstname format");

            if (userDto.UserLastname != null)
                if (!ServiceUtilities.IsValidName(userDto.UserLastname))
                    throw new BadRequestException("Invalid user lastname format");

            if (userDto.UserEmail != null)
                if (!ServiceUtilities.IsValidName(userDto.UserEmail))
                    throw new BadRequestException("Invalid user email format");

            if (userDto.UserPassword != null)
                if (!ServiceUtilities.IsValidName(userDto.UserPassword))
                    throw new BadRequestException("Invalid user password format");

            User user = await _userRepository.GetUserById(id);

            if (userDto.UserPassword != null)
                userDto.UserPassword = HashUtilities.HashPassword(userDto.UserPassword);

            ObjectUtilities.UpdateObject<User, UpdateUserDto>(user, userDto);

            await _userRepository.UpdateUser(user);

        }

    }
}