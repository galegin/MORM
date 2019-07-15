namespace MORM.Dominio.Interfaces
{
    public interface IAbstractUnityOfWork
    {
        IAbstractDataContext DataContext { get; }
        void SetAmbiente(IAmbiente ambiente);
    }

    public interface IAbstracAmbtUnityOfWork
    {
        IAmbiente Ambiente { get; }
    }
}