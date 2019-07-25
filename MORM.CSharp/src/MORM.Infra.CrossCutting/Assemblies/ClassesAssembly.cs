using System;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class ClassesAssembly
    {
        public static Type[] FromThisAssembly(Assembly assemblyPar = null)
        {
            var assembly = assemblyPar ?? Assembly.GetCallingAssembly();
            return assembly.GetTypes();
        }
    }
}