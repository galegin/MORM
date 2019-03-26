using System.Linq;

namespace MORM.Enums.Classes
{
    public static class EnunsExtensions
    {
        public static bool In<TEnun>(this TEnun enun, params TEnun[] enuns)
        {
            return enuns.Contains(enun);
        }
    }
}