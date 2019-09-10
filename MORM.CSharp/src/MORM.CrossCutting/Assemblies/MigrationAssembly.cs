using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public class MigrationAssembly
    {
        public static List<Assembly> GetAssemblies(Assembly assemblyPar = null)
        {
            var assembly = assemblyPar ?? Assembly.GetEntryAssembly();

            var assemblyNames = new List<string>
            {
                $".Dominio.",
            };

            return FilesAssembly
                .GetAssemblies(assembly, (x) => assemblyNames.Any(n => x.Contains(n)))
                ;
        }

        public static List<Type> GetTypes(Assembly assemblyPar = null, Func<Type, bool> filtro = null)
        {
            var types = new List<Type>();

            if (filtro == null)
                filtro = (f) => !string.IsNullOrWhiteSpace(f.Name);

            var assemblies = GetAssemblies(assemblyPar);

            assemblies.ForEach(assembly =>
            {
                assembly
                    .GetTypes()
                    .Where(filtro)
                    .ToList()
                    .ForEach(type => types.Add(type));
            });

            return types;
        }
    }
}