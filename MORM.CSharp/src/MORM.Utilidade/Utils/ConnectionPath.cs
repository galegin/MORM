using System;

namespace MORM.Utilidade.Utils
{
    //-- galeg - 12/06/2018 20:02:20
    public static class ConnectionPath
    {
        public static string GetAppPath(this string path)
        {
            return path.Replace("{appPath}", AppDomain.CurrentDomain.BaseDirectory); ;
        }
    }
}