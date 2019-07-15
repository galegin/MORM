using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MORM.Dominio.Interfaces
{
    public interface IConexao
    {
        IAmbiente Ambiente { get; }
        IDbConnection Connection { get; }
        IConexao ComParametros(IList<IParametro> parametros);
        void ExecComando(string cmd);
        DbDataReader GetConsulta(string sql);
        int ExecEscalar(string sql);
        void BeginTransaction();
        void CommitTransaction();
        void RoolBackTransaction();
    }
}