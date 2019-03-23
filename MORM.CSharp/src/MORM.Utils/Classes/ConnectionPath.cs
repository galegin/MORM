using System;

namespace MORM.Utils.Classes
{
    public static class ConnectionPath
    {
        public static string GetAppPath(this string path)
        {
            return path.Replace("{appPath}", AppDomain.CurrentDomain.BaseDirectory); ;
        }
    }
}