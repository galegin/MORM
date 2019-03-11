using MORM.Repositorio.IoC;
using MORM.Repositorio.Repositories;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Services
{
    //-- galeg - 01/05/2018 11:38:32
    public interface IAbstractService
    {
        IAbstractUnityOfWork AbstractUnityOfWork { get; }
        IAmbiente Ambiente { get; }
    }

    public interface IAbstractService<TObject> : IAbstractService where TObject : class
    {
        IAbstractRepository<TObject> AbstractRepository { get; }
    }
}