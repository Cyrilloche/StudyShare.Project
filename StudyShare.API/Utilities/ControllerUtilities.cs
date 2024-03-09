namespace StudyShare.API.Utilities
{
    public class ControllerUtilities
    {
        public static void InvalidIdVerification(int id)
        {
            if (id <= 0)
            {
                throw new BadHttpRequestException("Invalid ID exception");
            }
        }

        
    }
}