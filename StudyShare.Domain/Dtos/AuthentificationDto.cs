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

    }
}