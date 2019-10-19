namespace MORM.Apresentacao
{
    public interface IAbstractWindow
    {
        object Execute(object parameter = null);
        void FecharTela();
    }
}