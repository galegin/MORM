using MORM.Dominio.Interfaces;
using MORM.Dominio.Extensions;
using MORM.Repositorio.Migrations;
using MORM.Repositorio.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Repositorio.Context
{
    public class AbstractDataContext : IAbstractDataContext, IDisposable
    {
        public IAmbiente Ambiente { get; private set; }
        public IConexao Conexao { get; private set; }
        public IComando Comando { get; private set; }
        public IMigracao Migracao { get; private set; }

        public AbstractDataContext(IAmbiente ambiente)
        {
            SetAmbiente(ambiente);
            SetMigracao();
        }

        //-- set

        public IDbSet<TObject> Set<TObject>()
        {
            return new DbSet<TObject>(this);
        }

        //-- ambiente

        public void SetAmbiente(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
            Conexao = ConexaoFactory.GetConexao(ambiente);
            Comando = new Comando(ambiente.TipoDatabase);
            Migracao = new Migracao(this);
        }

        //-- migracao

        private void SetMigracao()
        {
            MigracaoContexto.Gerar(this);
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

            var dataReader = Conexao.GetConsulta(sql);

            while (dataReader.Read())
            {
                var obj = Activator.CreateInstance(type); 
                lista.Add(obj);
                obj.SetValueFromDataReader(dataReader);
                if (relacao)
                    this.GetRelacaoLista(obj, false);
            }

            dataReader.Close();
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
                .ComParametros(parametros)
                .GetConsulta(sql);

            if (dataReader.Read())
            {
                obj.SetValueFromDataReader(dataReader);
                if (relacao)
                    this.GetRelacaoLista(obj, true);
            }

            dataReader.Close();
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
                .ComParametros(parametrosKey)
                .GetConsulta(sql);

            var parametros = new List<IParametro>();

            var cmd = string.Empty;

            if (dataReader.Read())
                cmd = Comando
                    .ComParametros(parametros)
                    .GetUpdate();
            else
                cmd = Comando
                    .ComParametros(parametros)
                    .GetInsert();

            Conexao
                .ComParametros(parametros)
                .ExecComando(cmd);

            if (relacao)
                this.SetRelacaoLista(obj, true);

            dataReader.Close();
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
                .ComParametros(parametros)
                .ExecComando(cmd);

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
                .ComParametros(parametros)
                .ExecComando(cmd);

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
                .ComParametros(parametros)
                .ExecComando(cmd);

            if (relacao)
                this.RemRelacaoLista(obj, true);
        }

        public long IncObjeto<TObject>(object obj)
        {
            try
            {
                return this.GetSequenciaMaxO<TObject>(obj);
            }
            catch { return this.GetSequenciaGen<TObject>(); }
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