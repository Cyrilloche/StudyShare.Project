using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyShare.Application.Exceptions
{
    public class PasswordFormatException : Exception
    {
        public PasswordFormatException(string message) : base(message)
        {
            
        }
    }
}