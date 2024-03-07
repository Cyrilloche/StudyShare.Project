namespace StudyShare.Domain.Entities
{
    public class Paper
    {
        public int PaperId { get; set; }
        public string PaperName { get; set; } = string.Empty;
        public string? PaperDescription { get; set; }
        public string PaperPath { get; set; }  = string.Empty;
        public DateTime PaperUploadDate { get; set; }
        public int PaperDownloadsNumber { get; set; }
        public bool PaperVisibility { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<PaperClassLevel> PaperClassLevel { get; set; }
        public virtual ICollection<PaperKeyword> PaperKeyword { get; set; }






    }
}