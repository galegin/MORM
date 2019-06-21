using System;
using System.Reflection;

namespace MORM.Aplicacao.Ioc.Installer
{
    public class Classes
    {
        public static Type[] FromThisAssembly()
        {
            var assembly = Assembly.GetCallingAssembly();
            return assembly.GetTypes();
        }
    }
}