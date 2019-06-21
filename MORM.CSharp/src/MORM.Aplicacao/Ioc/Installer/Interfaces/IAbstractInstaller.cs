using MORM.Aplicacao.Ioc.Container;

namespace MORM.Aplicacao.Ioc.Installer
{
    public interface IAbstractInstaller
    {
        void Install(IAbstractContainer container);
    }
}