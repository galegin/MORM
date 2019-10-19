namespace MORM.Apresentacao
{
    public interface IMainWindow : IAbstractWindow
    {
        void Navegar(object sender);
        void SetarIsExibirMenuLateral(bool? flag = null);
    }
}