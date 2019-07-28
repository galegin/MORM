using MORM.Dominio.Interfaces;
using MORM.Infra.CrossCutting;

namespace MORM.Aplicacao.WebApi
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container
                .RegisterAll(
                    ClassesAssembly
                        .GetTypes(null, (t) => t.Name.EndsWith("Controller"))
                        .ToArray());
        }
    }
}