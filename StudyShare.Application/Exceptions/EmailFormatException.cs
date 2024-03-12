using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyShare.Application.Exceptions
{
    public class EmailFormatException : Exception
    {
        public EmailFormatException(string message) : base (message)
        {
            
        }
    }
}