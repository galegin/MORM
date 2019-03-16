using MORM.Ioc.Container;

namespace MORM.Apresentacao
{
    public interface IMainWindowExec
    {
        void SetMainWindow(IMainWindow mainWindow);
        IAbstractContainer Container { get; }
        void SetContainer(IAbstractContainer container);
        void Navegar(object sender);
        void SetarIsExibirMenuLateral();
    }
}