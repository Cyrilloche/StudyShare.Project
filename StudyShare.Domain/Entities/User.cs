using System.ComponentModel.DataAnnotations.Schema;

namespace StudyShare.Domain.Entities
{
    [Table("tbl_user")]
    public class User
    {

        public int UserId { get; set; }
        public string UserLastname { get; set; } = string.Empty;
        public string UserFirstname { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public int UserRoleId { get; set; }
        
        

        public virtual ICollection<UserSchool> UserSchool { get; set; }
        public virtual ICollection<UserWorkGroup> UserWorkGroup { get; set; }
        public virtual ICollection<UserClassLevel> UserClassLevel { get; set; }
        public virtual ICollection<Paper> Paper { get; set; }

    }
}