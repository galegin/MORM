using Dapper;
using MORM.CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Dapper
{
    public class AbstractDataContextDapper : IAbstractDataContextDapper, IDisposable
    {
        private IAmbiente _ambiente;
        private IConexao _conexao;
        private IComando _comando;
        private IMigracao _migracao;

        public AbstractDataContextDapper(IAmbiente ambiente)
        {
            SetAmbiente(ambiente);
        }

        //-- tipoDatabase

        public TipoDatabase GetTipoDatabase() => _ambiente.TipoDatabase;

        //-- conexao

        public IConexao GetConexao() => _conexao;

        //-- comando

        public IComando GetComando() => _comando;

        //-- migracao

        public IMigracao GetMigracao() => _migracao;

        //-- dbSet

        public IDbSet<TObject> Set<TObject>() => new DbSet<TObject>(this);

        //-- ambiente

        public void SetAmbiente(IAmbiente ambiente)
        {
            _ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
            _conexao = ConexaoFactory.GetConexao(ambiente);
            _comando = new Comando(ambiente.TipoDatabase);
            _migracao = new Migracao(this);
        }

        //-- migracao

        private void SetMigracao()
        {
            MigracaoContexto.Gerar(this);
        }

        //-- lista

        public IList GetLista(Type type, object filtro = null, bool relacao = false, int qtde = -1, int pagina = 0)
        {
            var lista = TypeForConvert.GetObjectFor(typeof(List<>), type) as IList;

            _ambiente.SetarFiltroPadrao(filtro);

            var where = filtro is string ? filtro as string : null;

            var sql = _comando
                .ComTipoObjeto(type)
                .ComWhere(where)
                .ComQtde(qtde)
                .ComPagina(pagina)
                .GetSelect();

            _conexao
                .Connection
                .Query(sql: sql, type: type)
                .ToList()
                .ForEach(dataReader =>
                {
                    var obj = Activator.CreateInstance(type);
                    lista.Add(obj);
                    obj.SetValueFromObjeto(dataReader);
                    if (relacao)
                        this.GetRelacaoLista(obj, false, _ambiente.TipoDatabase);
                });

            return lista;
        }

        //-- objeto

        public object GetObjeto(Type type, object filtro = null, bool relacao = true)
        {
            var obj = Activator.CreateInstance(type);

            _ambiente.SetarFiltroPadrao(filtro);

            var where = filtro is string ? filtro as string : null;

            var parametros = new List<IParametro>();

            var whereComando = _comando
                .ComObjeto(obj)
                .ComParametros(parametros)
                .GetWhereKey();

            var sql = _comando
                .ComWhere(where ?? whereComando)
                .GetSelect();

            var dataReader = _conexao
                .Connection
                .QueryFirstOrDefault(sql: sql, type: obj.GetType(), param: obj);

            if (dataReader != null)
            {
                obj.SetValueFromObjeto(dataReader);
                if (relacao)
                    this.GetRelacaoLista(obj, true, _ambiente.TipoDatabase);
            }

            return obj;
        }

        public void SetObjeto(object obj, bool relacao = true)
        {
            _ambiente.SetarValorPadrao(obj);

            obj.ValidarCampos();
            obj.ValidarTipagens();

            var parametrosKey = new List<IParametro>();

            var sql = _comando
                .ComObjeto(obj)
                .ComParametros(parametrosKey)
                .GetSelectKey();

            var dataReader = _conexao
                .Connection
                .QueryFirstOrDefault(sql: sql, type: obj.GetType(), param: obj);

            var parametros = new List<IParametro>();

            var cmd = string.Empty;

            if (dataReader != null)
                cmd = _comando
                    .ComParametros(parametros)
                    .GetUpdate();
            else
                cmd = _comando
                    .ComParametros(parametros)
                    .GetInsert();

            _conexao
                .Connection
                .Execute(sql: cmd, param: obj);

            if (relacao)
                this.SetRelacaoLista(obj, true);           
        }

        public void InsObjeto(object obj, bool relacao = true)
        {
            _ambiente.SetarValorPadrao(obj);

            obj.ValidarCampos();
            obj.ValidarTipagens();

            var parametros = new List<IParametro>();

            var cmd = _comando
                .ComObjeto(obj)
                .ComParametros(parametros)
                .GetInsert();

            _conexao
                .Connection
                .Execute(sql: cmd, param: obj);

            if (relacao)
                this.InsRelacaoLista(obj, true);
        }

        public void UpdObjeto(object obj, bool relacao = true)
        {
            _ambiente.SetarValorPadrao(obj);

            obj.ValidarCampos();
            obj.ValidarTipagens();

            var parametros = new List<IParametro>();

            var cmd = _comando
                .ComObjeto(obj)
                .ComParametros(parametros)
                .GetUpdate();

            _conexao
                .Connection
                .Execute(sql: cmd, param: obj);

            if (relacao)
                this.UpdRelacaoLista(obj, true);
        }

        public void RemObjeto(object obj, bool relacao = true)
        {
            _ambiente.SetarValorPadrao(obj);

            var parametros = new List<IParametro>();

            var cmd = _comando
                .ComObjeto(obj)
                .ComParametros(parametros)
                .GetDelete();

            _conexao
                .Connection
                .Execute(sql: cmd, param: obj);

            if (relacao)
                this.RemRelacaoLista(obj, true);
        }

        public long IncObjeto<TObject>(object filtro = null)
        {
            var where = filtro is string ? filtro as string : null;

            var sql = _comando
                .ComTipoObjeto(typeof(TObject))
                .ComWhere(where)
                .GetSequence();

            return _conexao
                .ExecEscalar(sql);
        }

        //-- dispose

        public void Dispose()
        {
            this.DesConectar();
            GC.SuppressFinalize(this);
        }

        ~AbstractDataContextDapper()
        {
            Dispose();
        }
    }
}