using MORM.Dominio.Interfaces;
using MORM.Infra.CrossCutting;
using System.Linq;

namespace MORM.Aplicacao.WebApi
{
    public class BaseInstaller
    {
        static BaseInstaller()
        {
            Install(AbstractContainer.Instance);
        }

        public static IAbstractContainer Container =>
            AbstractContainer.Instance;

        public static void Install(IAbstractContainer container)
        {
            container
                .RegisterAll(
                    ClassesAssembly
                    .FromThisAssembly()
                    .Where(t => t.Name.EndsWith("Controller"))
                    .ToArray());

            Servico.BaseInstaller.Install(container);
        }
    }
}