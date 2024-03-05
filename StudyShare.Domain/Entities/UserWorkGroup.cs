namespace StudyShare.Domain.Entities
{
    public class UserWorkGroup
    {

        public int UserId { get; set; }
        public User User { get; set; }
        public int WorkGroupId { get; set; }
        public WorkGroup WorkGroup { get; set; }
    }
}