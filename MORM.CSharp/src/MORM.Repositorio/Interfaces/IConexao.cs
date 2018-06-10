using System.Data.Common;

namespace MORM.Repositorio.Interfaces
{
    //-- galeg - 28/04/2018 20:26:06
    public interface IConexao
    {
        void ExecComando(string cmd);
        DbDataReader GetConsulta(string sql);
        int ExecEscalar(string sql);
        void BeginTransaction();
        void CommitTransaction();
        void RoolBackTransaction();
    }
}