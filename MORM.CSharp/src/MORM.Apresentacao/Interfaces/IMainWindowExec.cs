using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public interface IMainWindowExec
    {
        void SetMainWindow(IMainWindow mainWindow);
        void Navegar(UserControl userControl);
        void SetarIsExibirMenuLateral();
    }
}