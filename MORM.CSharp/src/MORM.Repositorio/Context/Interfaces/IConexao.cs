using MORM.Utilidade.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace MORM.Repositorio.Interfaces
{
    //-- galeg - 28/04/2018 20:26:06
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