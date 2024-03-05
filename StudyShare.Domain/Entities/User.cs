using System.ComponentModel.DataAnnotations.Schema;

namespace StudyShare.Domain.Entities
{
    [Table("tbl_user")]
    public class User
    {

        public int UserId { get; set; }
        public string UserLastname { get; set; }
        public string UserFirstname { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public virtual ICollection<UserSchool> UserSchool { get; set; }
        public virtual ICollection<UserWorkGroup> UserWorkGroup { get; set; }
        public virtual ICollection<UserClassLevel> UserClassLevel { get; set; }
        public virtual ICollection<Paper> Paper { get; set; }

    }
}