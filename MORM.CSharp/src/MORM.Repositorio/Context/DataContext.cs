using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using MORM.Utilidade.Interfaces;
using MORM.Utilidade.Tipagens;
using MORM.Utilidade.Atributos;
using MORM.Utilidade.Extensoes;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Migrations;
using MORM.Repositorio.Interfaces;

namespace MORM.Repositorio.Context
{
    public class DataContext : IDataContext, IDisposable
    {
        public DataContext()
        {
        }

        public DataContext(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
            Conexao = new Conexao(ambiente);
            Comando = new Comando(ambiente.TipoDatabase);
            Migracao = new Migracao(this);
        }
        
        public IAmbiente Ambiente { get; }
        public IConexao Conexao { get; }
        public IComando Comando { get; }
        public IMigracao Migracao { get; }

        //-- value

        private void SetValue(DbDataReader dataReader, object obj)
        {
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                var prop = obj.GetType().GetProperties()
                    .FirstOrDefault(x => x.Name == dataReader.GetName(i));
                if (prop != null)
                {
                    var value = (
                        dataReader.IsDBNull(i) ? null :
                        prop.PropertyType == typeof(bool) ? ".1.S.SIM.T.TRUE.".Contains(Convert.ToString(dataReader.GetValue(i))) :
                        prop.PropertyType == typeof(DateTime) ? Convert.ToDateTime(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(decimal) ? Convert.ToDecimal(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(double) ? Convert.ToDouble(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(float) ? Convert.ToSingle(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(long) ? Convert.ToInt64(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(int) ? Convert.ToInt32(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(short) ? Convert.ToInt16(dataReader.GetValue(i)) :
                        prop.PropertyType == typeof(string[]) ? Convert.ToString(dataReader.GetValue(i)).Split('|') :
                        prop.PropertyType == typeof(string) ? Convert.ToString(dataReader.GetValue(i)) : dataReader.GetValue(i));
                    prop.SetValue(obj, value);
                }
            }            
        }

        //-- get relacao

        private void GetRelacaoLista(object obj, bool inRelacao)
        {
            var relacoes = obj.GetType().GetRelacoesGet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                GetRelacao(val, relacao, inRelacao);
            }
        }

        private void GetRelacao(object obj, RelacaoAttribute relacao, bool inRelacao)
        {
            if (relacao == null)
                return;
            
            var campos = RelacaoCampos.GetRelacaoCampos(relacao.Campos);            
            var wheres = new List<string>();

            foreach (var campo in campos)
                wheres.Add(campo.Atributo + " = " + Comando.GetValueStr(relacao.OwnerObj, campo.AtributoRel));

            if (obj is IList)
                GetLista(obj as IList, string.Join(" and ", wheres), inRelacao);
            else if (obj is object)
                GetObjeto(obj as object, string.Join(" and ", wheres));
        }

        //-- set relacao

        private void SetRelacaoLista(object obj)
        {
            var relacoes = obj.GetType().GetRelacoesSet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                SetRelacao(val, relacao);
            }
        }

        private void SetRelacao(object obj, RelacaoAttribute relacao)
        {
            if (relacao == null)
                return;

            if (obj is IList)
                SetLista(obj as IList);
            else if (obj is object)
                SetObjeto(obj as object);
        }

        //-- ins relacao

        private void InsRelacaoLista(object obj)
        {
            var relacoes = obj.GetType().GetRelacoesSet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                InsRelacao(val, relacao);
            }
        }

        private void InsRelacao(object obj, RelacaoAttribute relacao)
        {
            if (relacao == null)
                return;

            if (obj is IList)
                InsLista(obj as IList);
            else if (obj is object)
                InsObjeto(obj as object);
        }

        //-- upd relacao

        private void UpdRelacaoLista(object obj)
        {
            var relacoes = obj.GetType().GetRelacoesSet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                UpdRelacao(val, relacao);
            }
        }

        private void UpdRelacao(object obj, RelacaoAttribute relacao)
        {
            if (relacao == null)
                return;

            if (obj is IList)
                UpdLista(obj as IList);
            else if (obj is object)
                UpdObjeto(obj as object);
        }

        //-- rem relacao

        private void RemRelacaoLista(object obj)
        {
            var relacoes = obj.GetType().GetRelacoesSet();
            foreach (var relacao in relacoes)
            {
                relacao.OwnerObj = obj;
                var val = relacao.OwnerProp.GetValue(obj);
                RemRelacao(val, relacao);
            }
        }

        private void RemRelacao(object obj, RelacaoAttribute relacao)
        {
            if (relacao == null)
                return;

            if (obj is IList)
                RemLista(obj as IList);
            else if (obj is object)
                RemObjeto(obj as object);
        }

        //-- lista

        public void GetLista(IList lista, string where = null, bool relacao = true, int qtde = -1, int pagina = 0)
        {
            var type = lista.GetType().GetGenericArguments().Single();

            this.SetarFiltroPadraoW(type, ref where);

            var sql = Comando.GetSelect(type, where, qtde, pagina);

            var dataReader = Conexao.GetConsulta(sql);

            while (dataReader.Read())
            {
                var obj = Activator.CreateInstance(type); 
                lista.Add(obj);
                SetValue(dataReader, obj);
                if (relacao)
                    GetRelacaoLista(obj, false);
            }

            dataReader.Close();
        }

        public IList<TObject> GetListaW<TObject>(string where, bool relacao = true, int qtde = -1, int pagina = 0)
        {
            var lista = new List<TObject>();
            GetLista(lista, where, relacao, qtde, pagina);
            return lista;
        }

        public IList<TObject> GetListaF<TObject>(Func<TObject, string> filtro, bool relacao = true, int qtde = -1, int pagina = 0)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            var lista = new List<TObject>();
            GetLista(lista, filtro?.Invoke(obj) ?? string.Empty, relacao, qtde, pagina);
            return lista;
        }

        public IList<TObject> GetListaO<TObject>(object objeto, bool relacao = true, int qtde = -1, int pagina = 0)
        {
            var lista = new List<TObject>();
            var listaDeCampoTipo = new[] { CampoTipo.Key, CampoTipo.Req, CampoTipo.Nul };
            GetLista(lista, Comando.GetWhereObj<TObject>(objeto, listaDeCampoTipo), relacao, qtde, pagina);
            return lista;
        }

        public void SetLista(IList lista, bool relacao = false)
        {
            foreach (var item in lista)
                SetObjeto(item, relacao);
        }

        public void InsLista(IList lista, bool relacao = false)
        {
            foreach (var item in lista)
                InsObjeto(item, relacao);
        }

        public void UpdLista(IList lista, bool relacao = false)
        {
            foreach (var item in lista)
                UpdObjeto(item, relacao);
        }

        public void RemLista(IList lista, bool relacao = false)
        {
            foreach (var item in lista)
                RemObjeto(item, relacao);
        }
        
        //-- objeto

        public void GetObjeto(object obj, string where = null, bool relacao = false)
        {
            this.SetarFiltroPadraoO(obj);

            var sql = Comando.GetSelect(obj.GetType(), where ?? Comando.GetWhereKey(obj));

            var dataReader = Conexao.GetConsulta(sql);

            if (dataReader.Read())
            {
                SetValue(dataReader, obj);
                if (relacao)
                    GetRelacaoLista(obj, true);
            }

            dataReader.Close();
        }

        public TObject GetObjetoW<TObject>(string where, bool relacao = false)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            GetObjeto(obj, where ?? Comando.GetWhereKey(obj), relacao);
            return obj;
        }

        public TObject GetObjetoF<TObject>(Func<TObject, string> filtro, bool relacao = false)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            GetObjeto(obj, filtro?.Invoke(obj) ?? Comando.GetWhereKey(obj), relacao);
            return obj;
        }

        public TObject GetObjetoO<TObject>(object objeto, bool relacao = false)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            var listaDeCampoTipo = new[] { CampoTipo.Key };
            GetObjeto(obj, Comando.GetWhereObj<TObject>(objeto, listaDeCampoTipo), relacao);
            return obj;
        }

        public void SetObjeto(object obj, bool relacao = false)
        {
            this.SetarValorPadraoO(obj);

            obj.ValidarCampos();
            obj.ValidarTipagens();

            var sql = Comando.GetSelect(obj);

            var dataReader = Conexao.GetConsulta(sql);
            var cmd = string.Empty;

            if (dataReader.Read())
                cmd = Comando.GetUpdate(obj);
            else
                cmd = Comando.GetInsert(obj);

            Conexao.ExecComando(cmd);

            if (relacao)
                SetRelacaoLista(obj);

            dataReader.Close();
        }

        public void InsObjeto(object obj, bool relacao = false)
        {
            this.SetarValorPadraoO(obj);

            obj.ValidarCampos();
            obj.ValidarTipagens();

            var sql = Comando.GetSelect(obj);

            var dataReader = Conexao.GetConsulta(sql);
            var cmd = Comando.GetInsert(obj);

            Conexao.ExecComando(cmd);

            if (relacao)
                InsRelacaoLista(obj);

            dataReader.Close();
        }

        public void UpdObjeto(object obj, bool relacao = false)
        {
            this.SetarValorPadraoO(obj);

            obj.ValidarCampos();
            obj.ValidarTipagens();

            var sql = Comando.GetSelect(obj);
            var dataReader = Conexao.GetConsulta(sql);
            var cmd = Comando.GetUpdate(obj);

            Conexao.ExecComando(cmd);

            if (relacao)
                UpdRelacaoLista(obj);

            dataReader.Close();
        }

        public void RemObjeto(object obj, bool relacao = false)
        {
            this.SetarValorPadraoO(obj);

            var cmd = Comando.GetDelete(obj);
            Conexao.ExecComando(cmd);

            if (relacao)
                RemRelacaoLista(obj);
        }

        //-- sequencia

        public int GetSequenciaGen<TObject>()
        {
            var sql = Comando.GetSequenciaGen(typeof(TObject));
            return Conexao.ExecEscalar(sql);
        }

        public int GetSequenciaMaxW<TObject>(string where)
        {
            var sql = Comando.GetSequenciaMax(typeof(TObject), where);
            return Conexao.ExecEscalar(sql);
        }

        public int GetSequenciaMaxF<TObject>(Func<TObject, string> filtro)
        {
            TObject obj = Activator.CreateInstance<TObject>();
            return GetSequenciaMaxW<TObject>(filtro?.Invoke(obj));
        }

        public int GetSequenciaMaxO<TObject>(object objeto)
        {
            var listaDeCampoTipo = new[] { CampoTipo.Key, CampoTipo.Req, CampoTipo.Nul };
            return GetSequenciaMaxW<TObject>(Comando.GetWhereObj<TObject>(objeto, listaDeCampoTipo));
        }

        //-- limits

        public string GetSelectLim<TObject>(string sql, int qtde, int pagina = 0)
        {
            return Ambiente.TipoDatabase.GetSelectLim(sql, qtde, pagina);
        }

        //-- valor padrao

        public object GetValor(ValorPadraoAttribute valorPadrao)
        {
            switch (valorPadrao.Tipo)
            {
                case TipoValorPadrao.EmpresaLogada:
                    return Ambiente.CodigoEmpresa;
                case TipoValorPadrao.UsuarioLogado:
                    return Ambiente.CodigoUsuario;
                case TipoValorPadrao.DataSistema:
                    return DateTime.Today;
                case TipoValorPadrao.HoraSistema:
                    return DateTime.Now;
                case TipoValorPadrao.ValorPadrao:
                    return valorPadrao.Valor;
            }

            return null;
        }

        //-- transaction

        public void BeginTransaction() => Conexao.BeginTransaction();
        public void CommitTransaction() => Conexao.CommitTransaction();
        public void RoolBackTransaction() => Conexao.RoolBackTransaction();

        //-- dispose

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        ~DataContext()
        {
            Dispose();
        }
    }
}