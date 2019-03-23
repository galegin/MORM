namespace MORM.Aplicacao.Ioc.Installer
{
    public interface IAbstractInstaller
    {
        void InstallerAmbiente();
        void InstallerCommands();
        void InstallerConexao();
        void InstallerDataConext();
        void InstallerDomainServices();
        void InstallerModels();
        void InstallerRepositories();
        void InstallerServices();
        void InstallerUnitOfWork();
        void InstallerViewModels();
        void InstallerViews();
    }
}