namespace StudyShare.Domain.Entities
{
    public class UserSchool
    {

        public int UserId { get; set; }
        public User User { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}