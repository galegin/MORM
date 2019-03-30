using MORM.Aplicacao.Ioc.Container;
using System.Windows.Controls;

namespace MORM.Apresentacao.Comps.Interfaces
{
    public interface ITelaUtils
    {
        IAbstractContainer Container { get; }
        IMainWindow MainWindow { get; }
        void NavegarPara(UserControl userControl);
        void VoltarTela(bool isAnterior = false);
        void VoltarTelaAnterior();
        void VoltarTelaInicio();
        bool? AbrirDialog(UserControl userControl, bool isFullScreen = false);
        void SetarIsExibirMenuLateral(bool? flag = null);
    }
}