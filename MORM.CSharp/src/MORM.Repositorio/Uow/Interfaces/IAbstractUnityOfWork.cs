using MORM.Repositorio.Interfaces;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Uow
{
    public interface IAbstractUnityOfWork
    {
        IAbstractDataContext DataContext { get; }
        IAmbiente Ambiente { get; }
        void SetAmbiente(IAmbiente ambiente);
    }
}