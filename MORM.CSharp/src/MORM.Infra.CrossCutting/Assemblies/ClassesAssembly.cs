using System;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class ClassesAssembly
    {
        public static Type[] FromThisAssembly()
        {
            var assembly = Assembly.GetCallingAssembly();
            return assembly.GetTypes();
        }
    }
}