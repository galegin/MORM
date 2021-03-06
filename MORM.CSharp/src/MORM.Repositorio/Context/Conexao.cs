using MORM.CrossCutting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MORM.Repositorio
{
    public class Conexao : IConexao
    {
        public Conexao(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
            Connection = ambiente.GetConnection();
            Connection.Open();
            SetarConexao();
        }

        public IAmbiente Ambiente { get; }
        public IDbConnection Connection { get; }

        private IList<IParametro> _parametros;

        public IConexao ComParametros(IList<IParametro> parametros)
        {
            _parametros = parametros;
            return this;
        }

        private void ResetarParametros()
        {
            _parametros = null;
        }

        // setar conexao

        private void SetarConexao()
        {
            var listaDeComando = Ambiente.TipoDatabase.GetListaDeComando();
            if (listaDeComando != null)
                foreach(var comando in listaDeComando)
                    ExecComando(comando);
        }

        // comando

        private DbCommand GetCommand(string cmd)
        {
            Logger.Debug("cmd: " + cmd);

            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            var command = (Connection as DbConnection).CreateCommand();
            command.CommandText = cmd;
            SetarParametro(command);
            return command;
        }

        // setar parametro

        private void SetarParametro(IDbCommand command)
        {
            if (_parametros == null)
                return;

            var listaParametro = new List<string>();

            foreach (var parametro in _parametros)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = parametro.Nome;
                parameter.Value = parametro.Valor;
                command.Parameters.Add(parameter);
                listaParametro.Add($"{parametro.Nome} = {parametro.Valor}");
            }

            Logger.Debug($"listaParametro: {string.Join(" / ", listaParametro)}");

            ResetarParametros();
        }

        // exec comando

        public void ExecComando(string cmd)
        {
            GetCommand(cmd).ExecuteNonQuery();
        }

        // get consulta

        public DbDataReader GetConsulta(string sql)
        {
            return GetCommand(sql).ExecuteReader();
        }

        // exec escalar

        public int ExecEscalar(string sql)
        {
            return Convert.ToInt32(GetCommand(sql).ExecuteScalar());
        }

        // transaction

        private IDbTransaction dbTransaction;

        public void BeginTransaction()
        {
            if (dbTransaction != null)
                throw new Exception(nameof(dbTransaction));

            dbTransaction = (Connection as DbConnection).BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (dbTransaction != null)
            {
                dbTransaction.Commit();
                dbTransaction = null;
            }
        }

        public void RoolBackTransaction()
        {
            if (dbTransaction != null)
            {
                dbTransaction.Rollback();
                dbTransaction = null;
            }
        }
    }
}