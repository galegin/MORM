using System;

namespace MORM.Infra.CrossCutting
{
    public static class ConnectionPath
    {
        public static string GetAppPath(this string path)
        {
            return path?.Replace("{appPath}", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}