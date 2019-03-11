using MORM.Utilidade.Interfaces;
using System.Data;
using Npgsql;

namespace MORM.Repositorio.PostgreSql
{
    public class PostgreSqlHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => 
            GetConnection(ambiente.Database, ambiente.Username, ambiente.Password, ambiente.Hostname);

        private static string ConnectionString(string database, string username, string password, string hostname)
        {
            var connStrBuilder = new NpgsqlConnectionStringBuilder()
            {
                Host = hostname,
                Port = 26500,
                Database = database,
                Username = username,
                Password = password,
                Timeout = 20,
                CommandTimeout = 20,
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string database, string username, string password, string hostname)
        {
            var connStrBuilder = ConnectionString(database, username, password, hostname);
            var connFact = new NpgsqlLiteFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}