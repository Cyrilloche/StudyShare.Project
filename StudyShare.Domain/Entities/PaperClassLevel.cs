namespace StudyShare.Domain.Entities
{
    public class PaperClassLevel
    {
        public int PaperId { get; set; }

        public Paper Paper { get; set; }

        public int ClassLevelId { get; set; }

        public ClassLevel ClassLevel { get; set; }


    }
}