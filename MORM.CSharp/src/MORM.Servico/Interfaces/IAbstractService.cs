using MORM.Dominio.Interfaces;
using MORM.Repositorio.Repositories;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Interfaces
{
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