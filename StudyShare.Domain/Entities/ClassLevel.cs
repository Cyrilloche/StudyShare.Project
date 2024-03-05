namespace StudyShare.Domain.Entities
{
    public class ClassLevel
    {
        public int ClassLevelId { get; set; }
        public string ClassLevelName { get; set; } = string.Empty;

        public virtual ICollection<UserClassLevel> UserClassLevel { get; set; }
        public virtual ICollection<PaperClassLevel> PaperClassLevel { get; set; }






    }
}