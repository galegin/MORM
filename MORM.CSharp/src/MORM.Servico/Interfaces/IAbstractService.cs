using MORM.Dominio.Interfaces;
using MORM.Repositorio.Repositories;
using MORM.Repositorio.Uow;
using System.Collections.Generic;

namespace MORM.Servico.Interfaces
{
    public interface IAbstractService
    {
        IAbstractUnityOfWork AbstractUnityOfWork { get; }
    }

    public interface IAbstractAmbService
    {
        IAmbiente Ambiente { get; }
    }

    public interface IAbstractService<TObject> : IAbstractService where TObject : class
    {
        IAbstractRepository<TObject> AbstractRepository { get; }
        List<TObject> Listar(TObject filtro);
        TObject Consultar(TObject filtro);
        void Incluir(TObject objeto);
        void Alterar(TObject objeto);
        void Salvar(TObject objeto);
        void Excluir(TObject objeto);
        int Sequencia(TObject filtro);
    }
}