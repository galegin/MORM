using System.Data;
using System.Data.SqlClient;
using System.IO;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.SqlServer
{
    //-- galeg - 28/04/2018 19:48:41
    public class SqlServerHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => GetConnection(ambiente.Database, ambiente.Username, ambiente.Password);

        private static string ConnectionString(string hostname, string username, string password)
        {
            var connStrBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = Path.Combine(hostname, username + ".mdf"),
                UserID = username,
                Password = password,
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string hostname, string username, string password)
        {
            var connStrBuilder = ConnectionString(hostname, username, password);
            var connFact = new SqlConnectionFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}