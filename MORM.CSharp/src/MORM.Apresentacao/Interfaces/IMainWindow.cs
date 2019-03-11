using System.Windows.Controls;

namespace MORM.Apresentacao
{
    public interface IMainWindow
    {
        bool? ShowDialog();
        void Navegar(UserControl userControl);
        void SetarIsExibirMenuLateral(bool? flag = null);
    }
}