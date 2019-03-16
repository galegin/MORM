using MORM.Repositorio.Context;
using MORM.Repositorio.Interfaces;

namespace MORM.Ioc.Installer
{
    public class AbstractDataContextInstaller : AbstractInstaller
    {
        protected override void Setup()
        {
            Register<IAbstractDataContext, AbstractDataContext>();
        }
    }
}