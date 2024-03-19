namespace StudyShare.Domain.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserLastname { get; set; } = string.Empty;
        public string UserFirstname { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public int UserRoleId { get; set; }
    }

    public class UpdateUserDto
    {
        public string? UserLastname { get; set; }
        public string? UserFirstname { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
    }

}