using System;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public class CampoAssembly
    {
        public static Type GetClasseCampo(string campo, Assembly assemblyPar = null)
        {
            var assembly = assemblyPar ?? Assembly.GetEntryAssembly();

            var nomeClasse = campo.GetPosFixo().ToLower();

            Func<Type, bool> filtro =
                (t) => t.Name.ToLower().StartsWith(nomeClasse) && t.GetProperty(campo) != null;

            var classeCampo = ClassesAssembly
                .GetTypes(assembly, filtro)
                .FirstOrDefault()
                ;

            return classeCampo;
        }
    }
}