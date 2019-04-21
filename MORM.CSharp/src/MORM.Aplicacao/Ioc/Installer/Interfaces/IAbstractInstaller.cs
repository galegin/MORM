namespace MORM.Aplicacao.Ioc.Installer
{
    public interface IAbstractInstaller
    {
        void InstallerAmbiente();
        void InstallerConexao();
        void InstallerDataConext();
        void InstallerDomainServices();
        void InstallerRepositories();
        void InstallerServices();
        void InstallerUnitOfWork();
        void InstallerViews();
    }
}