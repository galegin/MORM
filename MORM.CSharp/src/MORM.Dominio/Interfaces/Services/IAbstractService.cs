using System.Collections.Generic;

namespace MORM.Dominio.Interfaces
{
    public interface IAbstractService
    {
    }

    public interface IAbstractAmbService
    {
    }

    public interface IAbstractService<TObject> : IAbstractService
    {
        List<TObject> Listar(TObject filtro);
        TObject Consultar(TObject filtro);
        void Incluir(TObject objeto);
        void Alterar(TObject objeto);
        void Salvar(TObject objeto);
        void Excluir(TObject objeto);
        int Sequencia(TObject filtro);
    }
}