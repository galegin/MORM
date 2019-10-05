using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using MORM.Dominio.Types;
using MORM.CrossCutting;
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
                return context?.GetConexao()?.Connection?.State ?? null;
            }
            catch { }

            return null;
        }

        public static void Conectar(this IAbstractDataContext context)
        {
            if (context.GetConnectionState() == ConnectionState.Closed)
                context.GetConexao().Connection.Open();
        }

        public static void DesConectar(this IAbstractDataContext context)
        {
            if (context.GetConnectionState() == ConnectionState.Open)
                context.GetConexao().Connection.Close();
        }

        //-- lista

        public static IList<TObject> GetLista<TObject>(this IAbstractDataContext context, object filtro = null, bool relacao = true, int qtde = -1, int pagina = 0)
        {
            var listaDeCampoTipo = new[] { CampoTipo.Key, CampoTipo.Req, CampoTipo.Nul };
            var where = context.GetComando()
                .ComObjeto(filtro)
                .ComTipoCampo(listaDeCampoTipo)
                .GetWhereObj();
            return context.GetLista(typeof(TObject), where, relacao, qtde, pagina) as IList<TObject>;
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

        public static TObject GetObjeto<TObject>(this IAbstractDataContext context, object filtro = null, bool relacao = true)
        {
            var listaDeCampoTipo = new[] { CampoTipo.Key };
            var where = context.GetComando()
                .ComObjeto(filtro)
                .ComTipoCampo(listaDeCampoTipo)
                .GetWhereObj();
            return (TObject)context.GetObjeto(typeof(TObject), where, relacao);
        }

        //-- get relacao

        public static void GetRelacaoLista(this IAbstractDataContext context, object obj, bool inRelacao, TipoDatabase tipoDatabase)
        {
            var relacoes = obj.GetType().GetRelacoesGet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                if (val != null)
                {
                    var ret = context.GetRelacao(val.GetType(), relacao, inRelacao, tipoDatabase);
                    relacao.OwnerProp.SetValue(obj, ret);
                }
            }
        }

        private static object GetRelacao(this IAbstractDataContext context, Type type, RelacaoAttribute relacao, bool inRelacao, TipoDatabase tipoDatabase)
        {
            if (relacao == null)
                return null;

            var campos = RelacaoCampos.GetRelacaoCampos(relacao.Campos);
            var wheres = new List<string>();

            foreach (var campo in campos)
            {
                var value = relacao.OwnerObj.GetInstancePropOrField(campo.AtributoRel);
                wheres.Add($"{campo.Atributo} = {tipoDatabase.GetValueStr(value)}");
            }

            if (type is IList)
                return context.GetLista(type, string.Join(" and ", wheres), inRelacao);
            else if (type is object)
                return context.GetObjeto(type, string.Join(" and ", wheres));

            return null;
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
            if (relacao == null)
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
            if (relacao == null)
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
            if (relacao == null)
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
            if (relacao == null)
                return;

            if (obj is IList)
                context.RemLista(obj as IList, inRelacao);
            else if (obj is object)
                context.RemObjeto(obj as object);
        }

        //-- limits

        public static string GetSelectLim<TObject>(this TipoDatabase tipoDatabase, string sql, int qtde, int pagina = 0)
        {
            return tipoDatabase.GetSelectLim(sql, qtde, pagina);
        }

        //-- transaction

        public static void BeginTransaction(this IAbstractDataContext context) => 
            context.GetConexao().BeginTransaction();
        public static void CommitTransaction(this IAbstractDataContext context) =>
            context.GetConexao().CommitTransaction();
        public static void RoolBackTransaction(this IAbstractDataContext context) =>
            context.GetConexao().RoolBackTransaction();

        //-- valor padrao

        public static object GetValor(this IAmbiente ambiente, ValorPadraoAttribute valorPadrao)
        {
            switch (valorPadrao.Tipo)
            {
                case TipoValorPadrao.EmpresaLogada:
                    return ambiente.CodigoEmpresa;
                case TipoValorPadrao.UsuarioLogado:
                    return ambiente.CodigoUsuario;
                case TipoValorPadrao.TerminalLogado:
                    return ambiente.CodigoTerminal;
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
