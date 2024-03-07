namespace StudyShare.Domain.Entities
{
    public class WorkGroup
    {
        public int WorkGroupId { get; set; }
        public string WorkGroupName { get; set; }  = string.Empty;

        public virtual ICollection<UserWorkGroup> UserWorkGroup { get; set; }


    }
}