using System.Collections.Generic;

namespace MORM.Dominio.Interfaces
{
    public interface IAbstractRepository
    {
    }

    public interface IAbstractRepository<TObject> : IAbstractRepository
    {
        IList<TObject> Listar(object filtro = null, int qtde = -1, int pagina = 0, bool relacao = false);
        TObject Consultar(object filtro = null, bool relacao = true);
        void Incluir(object objeto, bool relacao = true);
        void Alterar(object objeto, bool relacao = true);
        void Salvar(object objeto, bool relacao = true);
        void Excluir(object objeto, bool relacao = true);
        long Sequencia(object filtro = null);
    }
}