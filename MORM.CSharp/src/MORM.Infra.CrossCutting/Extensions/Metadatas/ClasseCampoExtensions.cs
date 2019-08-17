using System;
using System.Linq;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public static class ClasseCampoExtensions
    {
        private static string[] _preFixo = { "Id", "Cd" };

        public static Type GetClasseCampo(this PropertyInfo prop)
        {
            var preFixo = prop.Name.GetPreFixo();
            var posFixo = prop.Name.GetPosFixo();
            var nameEnt = prop.ReflectedType.Name;
            if (_preFixo.Contains(preFixo) && !nameEnt.StartsWith(posFixo))
                return CampoAssembly.GetClasseCampo(prop.Name);
            return null;
        }

        public static bool IsClasseCampo(this PropertyInfo prop)
        {
            return prop.GetClasseCampo() != null;
        }
    }
}