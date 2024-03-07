namespace StudyShare.Application.Dtos
{
    public record UserDto(
            int UserId,
            string UserLastname,
            string UserFirstname,
            string UserEmail,
            string UserPassword
        );
}