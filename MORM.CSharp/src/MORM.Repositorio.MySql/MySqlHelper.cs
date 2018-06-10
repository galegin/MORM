using MORM.Utilidade.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace MORM.Repositorio.MySql
{
    public class MySqlHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => GetConnection(ambiente.Database, ambiente.Username, ambiente.Password, ambiente.Hostname);

        private static string ConnectionString(string hostname, string username, string password, string servname)
        {
            var connStrBuilder = new MySqlConnectionStringBuilder()
            {
                Database = hostname,
                UserID = username,
                Password = password,
                Server = servname,
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string hostname, string username, string password, string servname)
        {
            var connStrBuilder = ConnectionString(hostname, username, password, servname);
            var connFact = new MySqlClientFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}
