using System.Data;
using System.Data.SqlClient;
using System.IO;
using MORM.Utilidade.Interfaces;
using MORM.Utilidade.Utils;

namespace MORM.Repositorio.SqlServer
{
    //-- galeg - 28/04/2018 19:48:41
    public class SqlServerHelper : IConnectionFactory
    {
        public IDbConnection GetConnection(IAmbiente ambiente) => 
            GetConnection(ambiente.Database, ambiente.Username, ambiente.Password);

        private static string ConnectionString(string database, string username, string password)
        {
            var connStrBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = Path.Combine(database.GetAppPath(), username + ".mdf"),
                UserID = username,
                Password = password,
            };

            return connStrBuilder.ToString();
        }

        private static IDbConnection GetConnection(string database, string username, string password)
        {
            var connStrBuilder = ConnectionString(database, username, password);
            var connFact = new SqlConnectionFactory();
            var conn = connFact.CreateConnection();
            conn.ConnectionString = connStrBuilder;
            return conn;
        }
    }
}