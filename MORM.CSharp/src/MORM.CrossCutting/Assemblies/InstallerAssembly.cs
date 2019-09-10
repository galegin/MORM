using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public class InstallerAssembly
    {
        private static string[] _namespaces =
            { ".Aplicacao.", ".Apresentacao.", ".Database.", ".Dominio.", ".Repositorio.", ".Servico." };

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
                catch (Exception ex) { Logger.Debug("erro install", ex: ex); }
            }
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
                    ClasseExecute.Execute(type, "Install", new[] { container });
                });
        }
    }
}