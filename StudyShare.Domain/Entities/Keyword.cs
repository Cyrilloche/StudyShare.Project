namespace StudyShare.Domain.Entities
{
    public class Keyword
    {
        public int KeywordId { get; set; }
        public string KeywordName { get; set; } = string.Empty;

        public virtual ICollection<PaperKeyword> PaperKeyword { get; set; }



    }
}