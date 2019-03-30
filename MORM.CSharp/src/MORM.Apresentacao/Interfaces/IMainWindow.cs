namespace MORM.Apresentacao
{
    public interface IMainWindow
    {
        bool? ShowDialog();
        void Close();
        void Navegar(object sender);
        void SetarIsExibirMenuLateral(bool? flag = null);
    }
}