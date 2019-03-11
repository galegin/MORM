using Oracle.ManagedDataAccess.Client;
using MORM.Utilidade.Interfaces;
using System.Data;

namespace MORM.Repositorio.Oracle
{
    //-- galeg - 26/03/2018 20:07:52
    public class OracleHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => 
            GetConnection(ambiente.Database, ambiente.Username, ambiente.Password);

        static OracleHelper()
        {
            OracleHelperAmbiente.SetarVariavelAmbiente();
        }

        private static string ConnectionString(string database, string username, string password)
        {
            var connStrBuilder = new OracleConnectionStringBuilder()
            {
                DataSource = database,
                UserID = username,
                Password = password,
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string database, string username, string password)
        {
            var connStrBuilder = ConnectionString(database, username, password);
            var connFact = new OracleClientFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}