using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class ClassesAssembly
    {
        public static List<Type> GetTypes(Assembly assemblyPar = null, Func<Type, bool> filtro = null)
        {
            var assembly = assemblyPar ?? Assembly.GetCallingAssembly();
            
            if (filtro == null)
                filtro = (t) => !string.IsNullOrWhiteSpace(t.Name);
            
            return assembly
                .GetTypes()
                .Where(filtro)
                .ToList()
                ;
        }
    }
}