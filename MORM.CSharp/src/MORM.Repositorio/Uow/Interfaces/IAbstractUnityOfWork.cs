using MORM.Repositorio.Interfaces;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Uow
{
    //-- galeg - 28/04/2018 15:18:40
    public interface IAbstractUnityOfWork
    {
        IAbstractDataContext DataContext { get; }
        IAmbiente Ambiente { get; }
        void SetAmbiente(IAmbiente ambiente);
    }
}