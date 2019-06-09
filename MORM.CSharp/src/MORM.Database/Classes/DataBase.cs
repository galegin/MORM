using System.Data;

namespace MORM.Database
{
    public abstract class DataBase
    {
        #region Variaveis
        public string connectionString;
        #endregion

        #region Abstract Functions
        public abstract IDbConnection CreateConnection();
        public abstract IDbCommand CreateCommand();
        public abstract IDbConnection CreateOpenConnection();
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection);
        public abstract IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
        public abstract IDataParameter CreateParameter(string parameterName, object parameterValue);
        #endregion
    }
}