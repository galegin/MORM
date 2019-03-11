using MORM.IoC.Installer;
using MORM.Repositorio.Dapper.Context;

namespace MORM.Repositorio.Tests.IoC.Installer
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