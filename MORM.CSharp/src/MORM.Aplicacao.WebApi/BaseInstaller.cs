using MORM.Dominio.Interfaces;
using MORM.Infra.CrossCutting;
using System.Linq;

namespace MORM.Aplicacao.WebApi
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container
                .RegisterAll(
                    ClassesAssembly
                    .FromThisAssembly()
                    .Where(t => t.Name.EndsWith("Controller"))
                    .ToArray());
        }
    }
}