using MORM.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class InstallerAssembly
    {
        private static string[] _namespaces =
            { ".Aplicacao.", ".Apresentacao.", ".Dominio.", ".Infra.", ".Servico." };

        private static List<Assembly> _assemblies = new List<Assembly>();

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
            if (!IsContainLocation(assembly.Location))
                _assemblies.Add(assembly);
        }

        public static void Install(IAbstractContainer container)
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
                catch (Exception ex) { Logger.DebugException(ex); }
            }
        }

        private static void InstallAssembly(IAbstractContainer container, Assembly assembly)
        {
            if (assembly == null)
                return;

            var METHOD = $"{nameof(InstallerAssembly)}.InstallAssembly()";

            Logger.Debug(METHOD, $"assembly.FullName: {assembly.FullName}");

            var types = assembly.GetTypes()?.Where(x => x.Name.EndsWith("BaseInstaller"));

            foreach (var type in types)
            {
                Logger.Debug(METHOD, $"type.FullName: {type.FullName}");

                type.GetMethod("Install")?.Invoke(null, new[] { container });
            }
        }
    }
}