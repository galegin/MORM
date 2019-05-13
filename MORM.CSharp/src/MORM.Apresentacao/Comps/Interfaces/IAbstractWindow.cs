namespace MORM.Apresentacao.Comps
{
    public interface IAbstractWindow
    {
        object Execute(object parameter);
        void FecharTela();
    }
}