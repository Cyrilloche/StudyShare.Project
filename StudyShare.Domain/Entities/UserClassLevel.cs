namespace StudyShare.Domain.Entities
{
    public class UserClassLevel
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int ClassLevelId { get; set; }

        public ClassLevel ClassLevel { get; set; }
    }
}