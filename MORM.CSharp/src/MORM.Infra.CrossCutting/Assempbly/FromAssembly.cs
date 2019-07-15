using System;
using System.Linq;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class FromAssembly
    {
        public static object This()
        {
            var assembly = Assembly.GetCallingAssembly();
            var instance = assembly.GetTypes().FirstOrDefault(x => x.Name.EndsWith("Installer"));
            return Activator.CreateInstance(instance);
        }
    }
}