using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyShare.Domain.Dtos
{
    public class LoginDto
    {
        public required string UserEmail { get; set; }
        public required string UserPassword { get; set; }
        public int UserRoleId { get; set; }
    }
    public class CreateUserDto
    {
        public string UserFirstname { get; set; }

        public string UserLastname { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

    }
}