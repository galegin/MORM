using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class ServiceAssembly
    {
        public static bool IsContemServico(Assembly assemblyPar = null)
        {
            var assembly = assemblyPar ?? Assembly.GetEntryAssembly();

            var assemblyProjeto = assembly.FullName.GetLista('.').GetValue(0);

            var assemblyNames = new List<string>
            {
                $"{assemblyProjeto}.Servico"
            };

            return FilesAssembly
                .GetAssemblies(assembly, (x) => assemblyNames.Any(n => x.Contains(n)))
                .Any()
                ;
        }

        public static object Execute(Type typeRetorno, string metodo, object instance, object owner = null)
        {
            var serviceNome = GetServiceNome(instance, owner);
            var metodoNome = GetMetodoNome(instance, owner);
            var serviceObjeto = AbstractContainer.Instance.Resolve(serviceNome);
            var serviveRetorno = ObjetoExecute.Execute(serviceObjeto, metodoNome, new[] { instance });
            return ObjetoMapper.GetObjetoRetorno(typeRetorno, serviveRetorno);
        }

        public static TRetorno Execute<TEntrada, TRetorno>(string metodo, TEntrada instance, object owner = null)
        {
            return (TRetorno)Execute(typeof(TRetorno), metodo, instance, owner);
        }

        private static string GetServiceNome(object instance, object owner = null)
        {
            var classeNome = GetClasseNome(instance, owner);
            var serviceNome = $"I{classeNome}AppService";
            return serviceNome;
        }

        private static string GetClasseNome(object instance, object owner = null)
        {
            return instance.GetSvc()
                ?? (instance.GetUrl()?.GetLista('/')?.GetValue(0) as string)
                ?? owner?.GetSvc()
                ;
        }

        private static string GetMetodoNome(object instance, object owner = null)
        {
            return instance.GetMtd()
                ?? (instance.GetUrl()?.GetLista('/')?.GetValue(1) as string)
                ?? owner?.GetMtd()
                ;
        }
    }
}