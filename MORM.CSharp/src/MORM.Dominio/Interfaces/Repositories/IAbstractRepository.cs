using System;
using System.Collections.Generic;

namespace MORM.Dominio.Interfaces
{
    public interface IAbstractRepository
    {
        IAbstractDataContext DataContext { get; }
    }

    public interface IAbstractRepository<TObject> : IAbstractRepository
    {
        IQueryableObject<TObject> AsQueryable();
        IList<TObject> ListarF(Func<TObject, string> filtro, int qtde = -1, int pagina = 0, bool relacao = false);
        IList<TObject> ListarO(object objeto, int qtde = -1, int pagina = 0, bool relacao = false);
        IList<TObject> ListarW(string where, int qtde = -1, int pagina = 0, bool relacao = false);
        TObject ConsultarF(Func<TObject, string> filtro, bool relacao = true);
        TObject ConsultarO(object objeto, bool relacao = true);
        TObject ConsultarW(string where, bool relacao = true);
        void Incluir(IList<TObject> lista, bool relacao = true);
        void Incluir(TObject objeto, bool relacao = true);
        void Alterar(IList<TObject> lista, bool relacao = true);
        void Alterar(TObject objeto, bool relacao = true);
        void Salvar(IList<TObject> lista, bool relacao = true);
        void Salvar(TObject objeto, bool relacao = true);
        void Excluir(IList<TObject> lista, bool relacao = true);
        void Excluir(TObject objeto, bool relacao = true);
        int SequenciaGen();
        int SequenciaMaxF(Func<TObject, string> filtro);
        int SequenciaMaxO(object objeto);
        int SequenciaMaxW(string where);
        void preIncluir(TObject objeto);
        void posIncluir(TObject objeto);
        void preAlterar(TObject objeto);
        void posAlterar(TObject objeto);
        void preSalvar(TObject objeto);
        void posSalvar(TObject objeto);
        void preExcluir(TObject objeto);
        void posExcluir(TObject objeto); 
    }
}