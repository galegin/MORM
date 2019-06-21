using System;
using System.Linq;
using System.Reflection;

namespace MORM.Aplicacao.Ioc.Installer
{
    public class FromAssembly
    {
        public static IAbstractInstaller This()
        {
            var assembly = Assembly.GetCallingAssembly();
            var instance = assembly.GetTypes().FirstOrDefault(x => x.Name.EndsWith("Installer"));
            return (IAbstractInstaller)Activator.CreateInstance(instance);
        }
    }
}