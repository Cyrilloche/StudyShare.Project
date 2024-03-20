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

        public async Task DeleteUserAsync(int id)
        {
            if (!ServiceUtilities.IsValidId(id))
                throw new BadRequestException("Invalid id");
            await _userRepository.DeleteUserAsync(id);

        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            List<User> users = await _userRepository.GetAllUsersAsync();
            return DtosUtilities.ReturnIEnumerableDtosConverted<UserDto, User>(users).ToList();
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            if (!ServiceUtilities.IsValidId(id))
                throw new BadRequestException("Invalid id");

            return ObjectUtilities.MapObject<UserDto>(await _userRepository.GetUserByIdAsync(id));
        }

        public async Task UpdateUserAsync(int id, UpdateUserDto userDto)
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

            User user = await _userRepository.GetUserByIdAsync(id);

            if (userDto.UserPassword != null)
                userDto.UserPassword = HashUtilities.HashPassword(userDto.UserPassword);

            ObjectUtilities.UpdateObject<User, UpdateUserDto>(user, userDto);

            await _userRepository.UpdateUserAsync(user);

        }

    }
}