using MORM.Infra.CrossCutting;
using System;
using System.Linq;
using System.Reflection;

namespace MORM.Apresentacao.Views
{
    public static class ClasseCampoExtensions
    {
        private static string[] _preFixo = { "Id", "Cd" };

        public static Type GetClasseCampo(this PropertyInfo prop)
        {
            var preFixo = prop.Name.GetPreFixo();
            if (_preFixo.Contains(preFixo))
                return CampoAssembly.GetClasseCampo(prop.Name);
            return null;
        }

        public static bool IsClasseCampo(this PropertyInfo prop)
        {
            return prop.GetClasseCampo() != null;
        }
    }
}