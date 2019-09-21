using MORM.CrossCutting;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Factories;
using MORM.Repositorio.Migrations;
using MORM.Repositorio.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MORM.Repositorio.Context
{
    public class AbstractDataContext : IAbstractDataContext, IDisposable
    {
        private IAmbiente _ambiente;
        private IConexao _conexao;
        private IComando _comando;
        private IMigracao _migracao;

        public AbstractDataContext(IAmbiente ambiente)
        {
            SetAmbiente(ambiente);
            SetMigracao();
        }

        //-- conexao

        public IConexao GetConexao() => _conexao;

        //-- comando

        public IComando GetComando() => _comando;

        //-- set

        public IDbSet<TObject> Set<TObject>() => new DbSet<TObject>(this);

        //-- ambiente

        public void SetAmbiente(IAmbiente ambiente)
        {
            _ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
            _conexao = ConexaoFactory.GetConexao(ambiente);
            _comando = new Comando(ambiente.TipoDatabase);
            _migracao = new Migracao(GetMigracaoEntRepository(), _ambiente.TipoDatabase, _conexao);
        }

        //-- migracao

        private IMigracaoEntRepository GetMigracaoEntRepository() =>
            new MigracaoEntRepository(this);

        private void SetMigracao()
        {
            MigracaoContexto.Gerar(GetMigracaoEntRepository(), _migracao);
        }

        //-- lista

        public IList GetLista(Type type, object filtro = null, bool relacao = false, int qtde = -1, int pagina = 0)
        {
            var lista = TypeForConvert.GetTypeFor(typeof(List<>), type) as IList;

            _ambiente.SetarFiltroPadrao(filtro);

            var where = filtro is string ? filtro as string : null;

            var sql = _comando
                .ComTipoObjeto(type)
                .ComWhere(where)
                .ComQtde(qtde)
                .ComPagina(pagina)
                .GetSelect();

            var dataReader = _conexao.GetConsulta(sql);

            while (dataReader.Read())
            {
                var obj = Activator.CreateInstance(type); 
                lista.Add(obj);
                obj.SetValueFromDataReader(dataReader);
                if (relacao)
                    this.GetRelacaoLista(obj, false, _ambiente.TipoDatabase);
            }

            dataReader.Close();

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
                .ComParametros(parametros)
                .GetConsulta(sql);

            if (dataReader.Read())
            {
                obj.SetValueFromDataReader(dataReader);
                if (relacao)
                    this.GetRelacaoLista(obj, true, _ambiente.TipoDatabase);
            }

            dataReader.Close();

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
                .ComParametros(parametrosKey)
                .GetConsulta(sql);

            var parametros = new List<IParametro>();

            var cmd = string.Empty;

            if (dataReader.Read())
                cmd = _comando
                    .ComParametros(parametros)
                    .GetUpdate();
            else
                cmd = _comando
                    .ComParametros(parametros)
                    .GetInsert();

            _conexao
                .ComParametros(parametros)
                .ExecComando(cmd);

            if (relacao)
                this.SetRelacaoLista(obj, true);

            dataReader.Close();
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
                .ComParametros(parametros)
                .ExecComando(cmd);

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
                .ComParametros(parametros)
                .ExecComando(cmd);

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
                .ComParametros(parametros)
                .ExecComando(cmd);

            if (relacao)
                this.RemRelacaoLista(obj, true);
        }

        public long IncObjeto<TObject>(object filtro = null)
        {
            var where = filtro is string ? filtro as string : null;

            var sql = _comando
                .ComTipoObjeto(typeof(TObject))
                .ComWhere(where)
                .GetSequencia();

            return _conexao
                .ExecEscalar(sql);
        }

        //-- dispose

        public void Dispose()
        {
            this.DesConectar();
            GC.SuppressFinalize(this);
        }

        static AbstractDataContext()
        {
        }

        ~AbstractDataContext()
        {
            Dispose();
        }
    }
}