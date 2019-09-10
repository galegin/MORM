namespace MORM.CrossCutting
{
    public static class HashExtensions
    {
        public static string GetHash(params string[] lista)
        {
            return string.Join("#", lista);
        }
    }
}