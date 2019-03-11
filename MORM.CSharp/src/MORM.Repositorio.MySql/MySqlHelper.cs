using MORM.Utilidade.Interfaces;
using MySql.Data.MySqlClient;
using System.Data;

namespace MORM.Repositorio.MySql
{
    public class MySqlHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => 
            GetConnection(ambiente.Database, ambiente.Username, ambiente.Password, ambiente.Hostname);

        private static string ConnectionString(string database, string username, string password, string servname)
        {
            var connStrBuilder = new MySqlConnectionStringBuilder()
            {
                Database = database,
                UserID = username,
                Password = password,
                Server = servname,
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string database, string username, string password, string servname)
        {
            var connStrBuilder = ConnectionString(database, username, password, servname);
            var connFact = new MySqlClientFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}
