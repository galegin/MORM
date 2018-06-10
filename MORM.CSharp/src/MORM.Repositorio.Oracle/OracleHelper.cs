using Oracle.ManagedDataAccess.Client;
using MORM.Utilidade.Interfaces;
using System.Data;

namespace MORM.Repositorio.Oracle
{
    //-- galeg - 26/03/2018 20:07:52
    public class OracleHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => GetConnection(ambiente.Database, ambiente.Username, ambiente.Password);

        private static string ConnectionString(string hostname, string username, string password)
        {
            var connStrBuilder = new OracleConnectionStringBuilder()
            {
                DataSource = hostname,
                UserID = username,
                Password = password,
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string hostname, string username, string password)
        {
            var connStrBuilder = ConnectionString(hostname, username, password);
            var connFact = new OracleClientFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}