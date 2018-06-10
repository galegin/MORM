using MORM.Utilidade.Interfaces;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace MORM.Repositorio.SqLite
{
    public class SqLiteHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => GetConnection(ambiente.Database, ambiente.Username, ambiente.Password);

        private static string ConnectionString(string hostname, string username, string password)
        {
            var connStrBuilder = new SQLiteConnectionStringBuilder()
            {
                DataSource = Path.Combine(hostname, username + ".db"),
                Version = 3,
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string hostname, string username, string password)
        {
            var connStrBuilder = ConnectionString(hostname, username, password);
            var connFact = new SQLiteFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}