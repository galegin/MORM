using MORM.Dominio.Interfaces;
using System;

namespace MORM.Repositorio.Extensions
{
    public static class AmbienteExtensions
    {
        public static string GetConnectionString(this IAmbiente ambiente, string connectionString = null)
        {
            return ambiente.SetConnectionString(connectionString ?? ambiente.TipoDatabase.GetConnectionString());
        }

        private static string SetConnectionString(this IAmbiente ambiente, string connectionString)
        {
            return connectionString
                .Replace("{database}", ambiente.Database.GetAppPath())
                .Replace("{username}", ambiente.Username)
                .Replace("{password}", ambiente.Password)
                .Replace("{hostname}", ambiente.Hostname)
                ;
        }

        private static string GetAppPath(this string path)
        {
            return path?
                .Replace("{appPath}", AppDomain.CurrentDomain.BaseDirectory)
                .Replace("\\\\", "\\");
        }
    }
}