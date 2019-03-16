using MORM.Ioc.Installer;
using MORM.Repositorio.Context;
using MORM.Repositorio.Interfaces;

namespace MORM.Aplicacao.Ioc.Installer
{
    public class AbstractApiDataContextInstaller : AbstractDataContextInstaller
    {
        protected override void Setup()
        {
            Register<IAbstractDataContext, AbstractDataContext>();
        }
    }
}