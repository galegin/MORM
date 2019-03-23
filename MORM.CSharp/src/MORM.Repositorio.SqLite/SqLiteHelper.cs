using MORM.Dominio.Interfaces;
using MORM.Utils.Classes;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace MORM.Repositorio.SqLite
{
    public class SqLiteHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => 
            GetConnection(ambiente.Database, ambiente.Username, ambiente.Password);

        private static string ConnectionString(string database, string username, string password)
        {
            var connStrBuilder = new SQLiteConnectionStringBuilder()
            {
                DataSource = Path.Combine(database.GetAppPath(), username + ".db"),
                Version = 3,
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string database, string username, string password)
        {
            var connStrBuilder = ConnectionString(database, username, password);
            var connFact = new SQLiteFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}