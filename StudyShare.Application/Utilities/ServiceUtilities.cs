namespace StudyShare.Application.Utilities
{
    public class ServiceUtilities
    {
        public static void InvalidIdVerification(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid ID exception");
            }
        }
    }
}