using MORM.Repositorio.Interfaces;
using MORM.Utilidade.Interfaces;
using MORM.Utilidade.Tipagens;
using MORM.Utilidade.Utils;
using System;
using System.Data;
using System.Data.Common;

namespace MORM.Repositorio.Context
{
    public class Conexao : IConexao
    {
        public Conexao(IAmbiente ambiente)
        {
            Ambiente = ambiente ?? throw new ArgumentNullException(nameof(ambiente));
            Connection = DataContextConnection.GetConnection(ambiente);
            Connection.Open();
            SetarConexao();
        }

        public IAmbiente Ambiente { get; }
        public IDbConnection Connection { get; }

        // setar conexao

        private void SetarConexao()
        {
            var listaDeComando = Ambiente.TipoDatabase.GetListaDeComando();
            if (listaDeComando !=  null)
                foreach(var comando in listaDeComando)
                    ExecComando(comando);
        }

        // exec comando

        public void ExecComando(string cmd)
        {
            Logger.Debug($"{GetType().Name}.ExecComando()", "cmd: " + cmd);

            var command = Connection.CreateCommand();
            command.CommandText = cmd;
            command.ExecuteNonQuery();
        }

        // get consulta

        public DbDataReader GetConsulta(string sql)
        {
            Logger.Info($"{GetType().Name}.GetConsulta()", "sql: " + sql);

            var command = (Connection as DbConnection).CreateCommand();
            command.CommandText = sql;
            return command.ExecuteReader();
        }

        // exec escalar

        public int ExecEscalar(string sql)
        {
            Logger.Info($"{GetType().Name}.ExecEscalar()", "sql: " + sql);

            var command = Connection.CreateCommand();
            command.CommandText = sql;
            return Convert.ToInt32(command.ExecuteScalar());
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