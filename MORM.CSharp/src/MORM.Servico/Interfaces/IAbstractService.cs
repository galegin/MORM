using MORM.Dominio.Interfaces;
using MORM.Repositorio.Repositories;
using MORM.Repositorio.Uow;

namespace MORM.Servico.Interfaces
{
    public interface IAbstractService
    {
        IAbstractUnityOfWork AbstractUnityOfWork { get; }
    }

    public interface IAbstractService<TObject> : IAbstractService where TObject : class
    {
        IAbstractRepository<TObject> AbstractRepository { get; }
    }

    public interface IAbstractAmbService
    {
        IAmbiente Ambiente { get; }
    }
}