using MORM.Infra.CrossCutting;
using System.Windows.Controls;

namespace MORM.Apresentacao.Comps.Interfaces
{
    public interface ITelaUtils
    {
        IAbstractContainer Container { get; }
        IMainCommand MainCommand { get; }
        IMainWindow MainWindow { get; }
        IMainLogin MainLogin { get; }
        IMainMensagem MainMensagem { get; }
        void NavegarPara(UserControl userControl);
        void VoltarTela(bool isAnterior = false);
        void VoltarTelaAnterior();
        void VoltarTelaInicio();
        bool? AbrirDialog(UserControl userControl, bool isFullScreen = false);
        void SetarIsExibirMenuLateral(bool? flag = null);
    }
}