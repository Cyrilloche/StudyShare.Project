namespace StudyShare.Domain.Dtos
{
    public class PaperDto
    {
        public string PaperName { get; set; } = string.Empty;

        public string? PaperDescription { get; set; }

        public string PaperPath { get; set; } = string.Empty;
        public DateTime PaperUploadDate { get; set; }

        public int PaperDownloadsNumber { get; set; }

        public bool PaperVisibility { get; set; }

        public int UserId { get; set; }

    }

    public class UpdatePaperDto
    {
        public string? PaperDescription { get; set; }
        public bool PaperVisibility { get; set; }
    }

    public class CreatePaperDto
    {
        public string PaperName { get; set; } = string.Empty;
        public string? PaperDescription { get; set; }
        public DateTime PaperUploadDate { get; set; }
        public bool PaperVisibility { get; set; }
        public int UserId { get; set; }
    }
}