using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public static class InstallerAssembly
    {
        #region variaveis
        private static string[] _namespaces =
        {
            ".Aplicacao.",
            ".Apresentacao.",
            ".Database.",
            ".Dominio.",
            ".Driver.",
            ".Repositorio.",
            ".Servico."
        };

        private static List<Assembly> _assemblies = new List<Assembly>();
        #endregion

        #region metodos

        #region metodos publicos
        public static void AddInstaller(this IAbstractContainer container)
        {
            ClearAssembly();

            AddAssembly(Assembly.GetCallingAssembly());
            AddAssembly(Assembly.GetEntryAssembly());
            AddAssembly(Assembly.GetExecutingAssembly());

            FilesAssembly
                .GetAssemblies(null, (x) => IsContainName(x) && !IsContainLocation(x))
                .ForEach(assembly => AddAssembly(assembly))
                ;

            var assemblies = _assemblies.ToArray();

            foreach (var assembly in assemblies)
            {
                try
                {
                    InstallAssembly(container, assembly);
                }
                catch (Exception ex) { Logger.Debug("erro install", ex: ex); }
            }
        }
        #endregion

        #region metodos privados
        private static bool IsContainName(string name)
        {
            foreach (var namespc in _namespaces)
                if (name.Contains(namespc))
                    return true;

            return false;
        }

        private static void ClearAssembly()
        {
            _assemblies.Clear();
        }

        private static bool IsContainLocation(string location)
        {
            return _assemblies.Any(x => x.Location == location);
        }

        private static void AddAssembly(Assembly assembly)
        {
            if (assembly != null && !IsContainLocation(assembly.Location))
                _assemblies.Add(assembly);
        }

        private static void InstallAssembly(IAbstractContainer container, Assembly assembly)
        {
            if (assembly == null)
                return;

            Logger.Debug($"assembly.FullName: {assembly.FullName}");
            
            ClassesAssembly
                .GetTypes(assembly, (x) => x.Name.EndsWith("BaseInstaller"))
                .ForEach(type =>
                {
                    Logger.Debug($"type.FullName: {type.FullName}");

                    var method = type.GetMethods().FirstOrDefault(m => m.Name.StartsWith("Add"));
                    Logger.Debug($"method.Name: {method.Name}");

                    ClasseExecute.Execute(type, method.Name, new[] { container });
                });
        }
        #endregion

        #endregion
    }
}