using System.Data;

namespace Npgsql
{
    public class NpgsqlLiteFactory
    {
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection();
        }
    }
}