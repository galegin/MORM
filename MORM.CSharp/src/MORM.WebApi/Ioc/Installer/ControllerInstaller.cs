using MORM.Aplicacao.Ioc.Container;
using MORM.Aplicacao.Ioc.Installer;
using System.Linq;

namespace MORM.WebApi.Ioc
{
    public class ControllerInstaller : BaseInstaller
    {
        public override void Install(IAbstractContainer container)
        {
            base.Install(container);

            container
                .RegisterAll(
                    Classes
                    .FromThisAssembly()
                    .Where(t => t.Name.EndsWith("Controller"))
                    .ToArray());
        }
    }
}