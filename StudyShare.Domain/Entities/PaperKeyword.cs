namespace StudyShare.Domain.Entities
{
    public class PaperKeyword
    {

        public int PaperId { get; set; }
        public Paper Paper { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }




    }
}