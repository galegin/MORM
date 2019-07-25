using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class FilesAssembly
    {
        public static List<Assembly> GetAssemblies(Assembly assemblyPar = null, Func<string, bool> filtro = null)
        {
            var assemblies = new List<Assembly>();

            var assembly = assemblyPar ?? Assembly.GetExecutingAssembly();

            if (filtro == null)
                filtro = (x) => !string.IsNullOrWhiteSpace(x);

            var path = Path
                .GetDirectoryName(assembly.Location);

            var arquivos = Directory
                .GetFiles(path, "*.dll")
                .Where(filtro)
                .ToList();

            return arquivos
                .ConvertAll(arquivo => Assembly.LoadFile(arquivo))
                ;
        }
    }
}