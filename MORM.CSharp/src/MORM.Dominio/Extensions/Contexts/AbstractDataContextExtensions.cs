using MORM.Dominio.Atributos;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Dominio.Tipagens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MORM.Dominio.Extensions
{
    public static class AbstractDataContextExtensions
    {
        //-- conexao

        private static ConnectionState? GetConnectionState(this IAbstractDataContext context)
        {
            try
            {
                return context?.Conexao?.Connection?.State ?? null;
            }
            catch { }

            return null;
        }

        public static void Conectar(this IAbstractDataContext context)
        {
            if (context.GetConnectionState() == ConnectionState.Closed)
                context.Conexao.Connection.Open();
        }

        public static void DesConectar(this IAbstractDataContext context)
        {
            if (context.GetConnectionState() == ConnectionState.Open)
                context.Conexao.Connection.Close();
        }
        
        //-- lista

        public static IList<TObject> GetListaW<TObject>(this IAbstractDataContext context, string where, bool relacao = true, int qtde = -1, int pagina = 0)
        {
            var lista = new List<TObject>();
            context.GetLista(lista, where, relacao, qtde, pagina);
            return lista;
        }

        public static IList<TObject> GetListaF<TObject>(this IAbstractDataContext context, Func<TObject, string> filtro, bool relacao = true, int qtde = -1, int pagina = 0)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            var lista = new List<TObject>();
            context.GetLista(lista, filtro?.Invoke(obj), relacao, qtde, pagina);
            return lista;
        }

        public static IList<TObject> GetListaO<TObject>(this IAbstractDataContext context, object objeto, bool relacao = true, int qtde = -1, int pagina = 0)
        {
            var lista = new List<TObject>();
            var listaDeCampoTipo = new[] { CampoTipo.Key, CampoTipo.Req, CampoTipo.Nul };
            var where = context.Comando
                .ComObjeto(objeto)
                .ComTipoCampo(listaDeCampoTipo)
                .GetWhereObj();
            context.GetLista(lista, where, relacao, qtde, pagina);
            return lista;
        }

        public static void SetLista(this IAbstractDataContext context, IList lista, bool relacao = false)
        {
            foreach (var item in lista)
                context.SetObjeto(item, relacao);
        }

        public static void InsLista(this IAbstractDataContext context, IList lista, bool relacao = false)
        {
            foreach (var item in lista)
                context.InsObjeto(item, relacao);
        }

        public static void UpdLista(this IAbstractDataContext context, IList lista, bool relacao = false)
        {
            foreach (var item in lista)
                context.UpdObjeto(item, relacao);
        }

        public static void RemLista(this IAbstractDataContext context, IList lista, bool relacao = false)
        {
            foreach (var item in lista)
                context.RemObjeto(item, relacao);
        }

        //-- objeto

        public static TObject GetObjetoW<TObject>(this IAbstractDataContext context, string where, bool relacao = true)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            context.GetObjeto(obj, where, relacao);
            return obj;
        }

        public static TObject GetObjetoF<TObject>(this IAbstractDataContext context, Func<TObject, string> filtro, bool relacao = true)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            context.GetObjeto(obj, filtro?.Invoke(obj), relacao);
            return obj;
        }

        public static TObject GetObjetoO<TObject>(this IAbstractDataContext context, object objeto, bool relacao = true)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            var listaDeCampoTipo = new[] { CampoTipo.Key };
            var where = context.Comando
                .ComObjeto(objeto)
                .ComTipoCampo(listaDeCampoTipo)
                .GetWhereObj();
            context.GetObjeto(obj, where, relacao);
            return obj;
        }

        //-- get relacao

        public static void GetRelacaoLista(this IAbstractDataContext context, object obj, bool inRelacao)
        {
            var relacoes = obj.GetType().GetRelacoesGet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                context.GetRelacao(val, relacao, inRelacao);
            }
        }

        private static void GetRelacao(this IAbstractDataContext context, object obj, RelacaoAttribute relacao, bool inRelacao)
        {
            if (relacao == null)
                return;

            var campos = RelacaoCampos.GetRelacaoCampos(relacao.Campos);
            var wheres = new List<string>();

            foreach (var campo in campos)
            {
                var value = relacao.OwnerObj.GetInstancePropOrField(campo.AtributoRel);
                wheres.Add($"{campo.Atributo} = {context.Ambiente.TipoDatabase.GetValueStr(value)}");
            }

            if (obj is IList)
                context.GetLista(obj as IList, string.Join(" and ", wheres), inRelacao);
            else if (obj is object)
                context.GetObjeto(obj as object, string.Join(" and ", wheres));
        }

        //-- set relacao

        public static void SetRelacaoLista(this IAbstractDataContext context, object obj, bool inRelacao)
        {
            var relacoes = obj.GetType().GetRelacoesSet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                context.SetRelacao(val, relacao, inRelacao);
            }
        }

        private static void SetRelacao(this IAbstractDataContext context, object obj, RelacaoAttribute relacao, bool inRelacao)
        {
            if (relacao == null/* || obj == null*/)
                return;

            if (obj is IList)
                context.SetLista(obj as IList, inRelacao);
            else if (obj is object)
                context.SetObjeto(obj as object);
        }

        //-- ins relacao

        public static void InsRelacaoLista(this IAbstractDataContext context, object obj, bool inRelacao)
        {
            var relacoes = obj.GetType().GetRelacoesSet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                context.InsRelacao(val, relacao, inRelacao);
            }
        }

        private static void InsRelacao(this IAbstractDataContext context, object obj, RelacaoAttribute relacao, bool inRelacao)
        {
            if (relacao == null/* || obj == null*/)
                return;

            if (obj is IList)
                context.InsLista(obj as IList, inRelacao);
            else if (obj is object)
                context.InsObjeto(obj as object);
        }

        //-- upd relacao

        public static void UpdRelacaoLista(this IAbstractDataContext context, object obj, bool inRelacao)
        {
            var relacoes = obj.GetType().GetRelacoesSet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                context.UpdRelacao(val, relacao, inRelacao);
            }
        }

        private static void UpdRelacao(this IAbstractDataContext context, object obj, RelacaoAttribute relacao, bool inRelacao)
        {
            if (relacao == null/* || obj == null*/)
                return;

            if (obj is IList)
                context.UpdLista(obj as IList, inRelacao);
            else if (obj is object)
                context.UpdObjeto(obj as object);
        }

        //-- rem relacao

        public static void RemRelacaoLista(this IAbstractDataContext context, object obj, bool inRelacao)
        {
            var relacoes = obj.GetType().GetRelacoesSet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                context.RemRelacao(val, relacao, inRelacao);
            }
        }

        private static void RemRelacao(this IAbstractDataContext context, object obj, RelacaoAttribute relacao, bool inRelacao)
        {
            if (relacao == null/* || obj == null*/)
                return;

            if (obj is IList)
                context.RemLista(obj as IList, inRelacao);
            else if (obj is object)
                context.RemObjeto(obj as object);
        }

        //-- sequencia

        public static int GetSequenciaGen<TObject>(this IAbstractDataContext context)
        {
            var sql = context.Comando
                .ComTipoObjeto(typeof(TObject))
                .GetSequenciaGen();
            return context.Conexao.ExecEscalar(sql);
        }

        public static int GetSequenciaMaxW<TObject>(this IAbstractDataContext context, string where)
        {
            var sql = context.Comando
                .ComTipoObjeto(typeof(TObject))
                .ComWhere(where)
                .GetSequenciaMax();
            return context.Conexao.ExecEscalar(sql);
        }

        public static int GetSequenciaMaxF<TObject>(this IAbstractDataContext context, Func<TObject, string> filtro)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            return context.GetSequenciaMaxW<TObject>(filtro?.Invoke(obj));
        }

        public static int GetSequenciaMaxO<TObject>(this IAbstractDataContext context, object objeto)
        {
            var listaDeCampoTipo = new[] { CampoTipo.Key, CampoTipo.Req, CampoTipo.Nul };
            var where = context.Comando
                .ComObjeto(objeto)
                .ComTipoCampo(listaDeCampoTipo)
                .GetWhereObj();
            return context.GetSequenciaMaxW<TObject>(where);
        }

        //-- limits

        public static string GetSelectLim<TObject>(this IAbstractDataContext context, string sql, int qtde, int pagina = 0)
        {
            return context.Ambiente.TipoDatabase.GetSelectLim(sql, qtde, pagina);
        }

        //-- transaction

        public static void BeginTransaction(this IAbstractDataContext context) => context.Conexao.BeginTransaction();
        public static void CommitTransaction(this IAbstractDataContext context) => context.Conexao.CommitTransaction();
        public static void RoolBackTransaction(this IAbstractDataContext context) => context.Conexao.RoolBackTransaction();

        //-- valor padrao

        public static object GetValor(this IAbstractDataContext context, ValorPadraoAttribute valorPadrao)
        {
            switch (valorPadrao.Tipo)
            {
                case TipoValorPadrao.EmpresaLogada:
                    return context.Ambiente.CodigoEmpresa;
                case TipoValorPadrao.UsuarioLogado:
                    return context.Ambiente.CodigoUsuario;
                case TipoValorPadrao.TerminalLogado:
                    return context.Ambiente.CodigoTerminal;
                case TipoValorPadrao.DataSistema:
                    return DateTime.Today;
                case TipoValorPadrao.HoraSistema:
                    return DateTime.Now;
                case TipoValorPadrao.ValorPadrao:
                    return valorPadrao.Valor;
            }

            return null;
        }
    }
}
