using Dapper;
using MORM.Repositorio.Context;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Factories;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Migrations;
using MORM.Dominio.Extensoes;
using MORM.Dominio.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Dapper.Context
{
    public class AbstractDataContextDapper : IAbstractDataContextDapper, IDisposable
    {
        static AbstractDataContextDapper()
        {

        }

        public AbstractDataContextDapper(IAmbiente ambiente, IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            SetAmbiente(ambiente);
        }

        private readonly IConnectionFactory _connectionFactory;

        //-- interface

        public IAmbiente Ambiente { get; private set; }
        public IConexao Conexao { get; private set; }
        public IComando Comando { get; private set; }
        public IMigracao Migracao { get; private set; }

        //-- ambiente

        public void SetAmbiente(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
            Conexao = ConexaoFactory.GetConexao(ambiente, _connectionFactory);
            Comando = new Comando(ambiente.TipoDatabase);
            Migracao = new Migracao(this);
        }

        //-- lista

        public void GetLista(IList lista, string where = null, bool relacao = false, int qtde = -1, int pagina = 0)
        {
            var type = lista.GetType().GetGenericArguments().Single();

            this.SetarFiltroPadraoW(type, ref where);

            var sql = Comando
                .ComTipoObjeto(type)
                .ComWhere(where)
                .ComQtde(qtde)
                .ComPagina(pagina)
                .GetSelect();

            Conexao
                .Connection
                .Query(sql: sql, type: type)
                .ToList()
                .ForEach(dataReader =>
                {
                    var obj = Activator.CreateInstance(type);
                    lista.Add(obj);
                    obj.SetValueFromObjeto(dataReader);
                    if (relacao)
                        this.GetRelacaoLista(obj, false);
                });
        }

        //-- objeto

        public void GetObjeto(object obj, string where = null, bool relacao = true)
        {
            this.SetarFiltroPadraoO(obj);

            var parametros = new List<IParametro>();

            var whereComando = Comando
                .ComObjeto(obj)
                .ComParametros(parametros)
                .GetWhereKey();

            var sql = Comando
                .ComWhere(where ?? whereComando)
                .GetSelect();

            var dataReader = Conexao
                .Connection
                .QueryFirstOrDefault(sql: sql, type: obj.GetType(), param: obj);

            if (dataReader != null)
            {
                obj.SetValueFromObjeto(dataReader);
                if (relacao)
                    this.GetRelacaoLista(obj, true);
            }
        }

        public void SetObjeto(object obj, bool relacao = true)
        {
            this.SetarValorPadraoO(obj);

            obj.ValidarCampos();
            obj.ValidarTipagens();

            var parametrosKey = new List<IParametro>();

            var sql = Comando
                .ComObjeto(obj)
                .ComParametros(parametrosKey)
                .GetSelectKey();

            var dataReader = Conexao
                .Connection
                .QueryFirstOrDefault(sql: sql, type: obj.GetType(), param: obj);

            var parametros = new List<IParametro>();

            var cmd = string.Empty;

            if (dataReader != null)
                cmd = Comando
                    .ComParametros(parametros)
                    .GetUpdate();
            else
                cmd = Comando
                    .ComParametros(parametros)
                    .GetInsert();

            Conexao
                .Connection
                .Execute(sql: cmd, param: obj);

            if (relacao)
                this.SetRelacaoLista(obj, true);           
        }

        public void InsObjeto(object obj, bool relacao = true)
        {
            this.SetarValorPadraoO(obj);

            obj.ValidarCampos();
            obj.ValidarTipagens();

            var parametros = new List<IParametro>();

            var cmd = Comando
                .ComObjeto(obj)
                .ComParametros(parametros)
                .GetInsert();

            Conexao
                .Connection
                .Execute(sql: cmd, param: obj);

            if (relacao)
                this.InsRelacaoLista(obj, true);
        }

        public void UpdObjeto(object obj, bool relacao = true)
        {
            this.SetarValorPadraoO(obj);

            obj.ValidarCampos();
            obj.ValidarTipagens();

            var parametros = new List<IParametro>();

            var cmd = Comando
                .ComObjeto(obj)
                .ComParametros(parametros)
                .GetUpdate();

            Conexao
                .Connection
                .Execute(sql: cmd, param: obj);

            if (relacao)
                this.UpdRelacaoLista(obj, true);
        }

        public void RemObjeto(object obj, bool relacao = true)
        {
            this.SetarValorPadraoO(obj);

            var parametros = new List<IParametro>();

            var cmd = Comando
                .ComObjeto(obj)
                .ComParametros(parametros)
                .GetDelete();

            Conexao
                .Connection
                .Execute(sql: cmd, param: obj);

            if (relacao)
                this.RemRelacaoLista(obj, true);
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