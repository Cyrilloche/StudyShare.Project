namespace StudyShare.Domain.Entities
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; } = string.Empty;

        public virtual ICollection<UserSchool> UserSchool { get; set; }



    }
}