using FirebirdSql.Data.FirebirdClient;
using MORM.Utilidade.Interfaces;
using System.Data;
using System.IO;

namespace MORM.Repositorio.Firebird
{
    public class FirebirdHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => GetConnection(ambiente.Database, ambiente.Username, ambiente.Password);

        private static string ConnectionString(string hostname, string username, string password)
        {
            var connStrBuilder = new FbConnectionStringBuilder()
            {
                DataSource = Path.Combine(hostname, username + ".fdb"),
                UserID = "SYSDBA",
                Password = "masterkey",
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string hostname, string username, string password)
        {
            var connStrBuilder = ConnectionString(hostname, username, password);
            var connFact = new FbClientFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}