namespace MORM.Infra.CrossCutting
{
    public static class HashExtensions
    {
        public static string GetHash(params string[] lista)
        {
            return string.Join("#", lista);
        }
    }
}