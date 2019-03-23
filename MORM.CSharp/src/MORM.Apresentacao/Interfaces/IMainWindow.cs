using MORM.Aplicacao.Ioc.Container;

namespace MORM.Apresentacao
{
    public interface IMainWindow
    {
        bool? ShowDialog();
        void Navegar(object sender);
        void SetarIsExibirMenuLateral(bool? flag = null);
        void SetContainer(IAbstractContainer container);
    }
}