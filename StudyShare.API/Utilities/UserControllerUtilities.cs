using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace StudyShare.API.Utilities
{
    public class UserControllerUtilities
    {
        public static void InvalidIdVerification(int userId)
        {
            if (userId <= 0)
            {
                throw new BadHttpRequestException("Invalid ID exception");
            }
        }
    }
}