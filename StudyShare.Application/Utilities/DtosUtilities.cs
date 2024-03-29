using StudyShare.Domain.Utilities;

namespace StudyShare.Application.Utilities
{
    public class DtosUtilities
    {
        public static IEnumerable<T1> ReturnIEnumerableDtosConverted<T1, T2>(List<T2> list)
        {
            List<T1> dtos = new List<T1>();

            foreach (var item in list)
            {
                if (item != null)
                    dtos.Add(ObjectUtilities.MapObject<T1>(item));
            }

            return dtos;
        }

    }
}