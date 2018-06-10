using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.IoC
{
    //-- galeg - 28/04/2018 15:18:40
    public interface IUnityOfWork
    {
        IAmbiente Ambiente { get; }
    }
}