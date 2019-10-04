using System;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public static class ClasseCampoExtensions
    {
        private static string[] _preFixo = { "Id", "Cd" };

        public static Type GetClasseCampo(this PropertyInfo prop)
        {
            //if (!prop.PropertyType.IsClass)
            //    return null;

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