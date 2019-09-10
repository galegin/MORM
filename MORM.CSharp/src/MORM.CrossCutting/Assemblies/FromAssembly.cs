using System;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public class FromAssembly
    {
        public static object This(Assembly assemblyPar = null)
        {
            var assembly = assemblyPar ?? Assembly.GetCallingAssembly();
            var instanceType = assembly.GetTypes().FirstOrDefault(x => x.Name.EndsWith("Installer"));
            return Activator.CreateInstance(instanceType);
        }
    }
}