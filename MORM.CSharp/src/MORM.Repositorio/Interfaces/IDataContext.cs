using MORM.Utilidade.Atributos;
using MORM.Utilidade.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MORM.Repositorio.Interfaces
{
    //-- galeg - 28/04/2018 15:24:57
    public interface IDataContext
    {
        IAmbiente Ambiente { get; }
        IConexao Conexao { get; }
        IComando Comando { get; }
        IMigracao Migracao { get; }
        void GetLista(IList lista, string where = null, bool relacao = false, int qtde = -1, int pagina = 0);
        IList<TObject> GetListaW<TObject>(string where, bool relacao = false, int qtde = -1, int pagina = 0);
        IList<TObject> GetListaF<TObject>(Func<TObject, string> filtro, bool relacao = false, int qtde = -1, int pagina = 0);
        IList<TObject> GetListaO<TObject>(object objeto, bool relacao = false, int qtde = -1, int pagina = 0);
        void SetLista(IList lista, bool relacao = false);
        void InsLista(IList lista, bool relacao = false);
        void UpdLista(IList lista, bool relacao = false);
        void RemLista(IList lista, bool relacao = false);
        void GetObjeto(object obj, string where = null, bool relacao = true);
        TObject GetObjetoW<TObject>(string where, bool relacao = true);
        TObject GetObjetoF<TObject>(Func<TObject, string> filtro, bool relacao = true);
        TObject GetObjetoO<TObject>(object objeto, bool relacao = true);
        void SetObjeto(object obj, bool relacao = false);
        void InsObjeto(object obj, bool relacao = false);
        void UpdObjeto(object obj, bool relacao = false);
        void RemObjeto(object obj, bool relacao = false);
        int GetSequenciaGen<TObject>();
        int GetSequenciaMaxW<TObject>(string where);
        int GetSequenciaMaxF<TObject>(Func<TObject, string> filtro);
        int GetSequenciaMaxO<TObject>(object objeto);
        string GetSelectLim<TObject>(string sql, int qtde, int pagina = 0);
        object GetValor(ValorPadraoAttribute valorPadrao);
        void BeginTransaction();
        void CommitTransaction();
        void RoolBackTransaction();
    }
}