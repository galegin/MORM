using MORM.Repositorio.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Repositorio.Repositories
{
    //-- galeg - 01/05/2018 11:38:08
    public interface IAbstractRepository
    {
        IDataContext DataContext { get; }
    }

    public interface IAbstractRepository<TObject> : IAbstractRepository where TObject : class
    {
        IList<TObject> ListarF(Func<TObject, string> filtro, int qtde = -1, int pagina = 0);
        IList<TObject> ListarO(object objeto, int qtde = -1, int pagina = 0);
        IList<TObject> ListarW(string where, int qtde = -1, int pagina = 0);
        TObject ConsultarF(Func<TObject, string> filtro);
        TObject ConsultarO(object objeto);
        TObject ConsultarW(string where);
        void Incluir(IList<TObject> lista);
        void Incluir(TObject objeto);
        void Alterar(IList<TObject> lista);
        void Alterar(TObject objeto);
        void Salvar(IList<TObject> lista);
        void Salvar(TObject objeto);
        void Excluir(IList<TObject> lista);
        void Excluir(TObject objeto);
        int SequenciaGen();
        int SequenciaMaxF(Func<TObject, string> filtro);
        int SequenciaMaxO(object objeto);
        int SequenciaMaxW(string where);
    }
}