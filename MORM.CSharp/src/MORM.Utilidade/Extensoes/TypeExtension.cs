using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MORM.Utilidade.Extensoes
{
    //-- galeg - 03/06/2018 11:05:08
    public static class TypeExtension
    {
        public static Type[] GetListaDeClasse(this string package, string baseType = null)
        {
            if (package == null)
                throw new ArgumentNullException(nameof(package));

            if (!File.Exists(package))
                return null;

            Assembly assembly = Assembly.LoadFile(package);

            var listaDeClasse = assembly.GetTypes();

            if (!string.IsNullOrEmpty(baseType))
                listaDeClasse = listaDeClasse
                    .Where(x => x.BaseType.Name.ToLower() == baseType.ToLower())
                    .ToArray();

            return listaDeClasse;
        }

        public static Type[] GetListaDeClasse<TObject>(string baseType = null)
        {
            return GetListaDeClasse(typeof(TObject).Assembly.Location, baseType);
        }
    }
}