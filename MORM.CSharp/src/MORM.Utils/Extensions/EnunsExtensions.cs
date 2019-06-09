using System.Linq;

namespace MORM.Utils.Extensions
{
    public static class EnunsExtensions
    {
        public static bool In<TEnun>(this TEnun enun, params TEnun[] enuns)
        {
            return enuns.Contains(enun);
        }
    }
}