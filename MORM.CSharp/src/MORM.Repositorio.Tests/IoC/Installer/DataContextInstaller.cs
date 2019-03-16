using MORM.Ioc.Installer;
using MORM.Repositorio.Dapper.Context;

namespace MORM.Repositorio.Tests.Ioc.Installer
{
    public class DataContextInstaller : AbstractDataContextInstaller
    {
        protected override void Setup()
        {
            base.Setup();

            Register<IAbstractDataContextDapper, AbstractDataContextDapper>();
        }
    }
}