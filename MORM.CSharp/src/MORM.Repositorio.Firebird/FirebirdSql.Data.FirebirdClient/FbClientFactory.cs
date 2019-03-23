using System.Data.Common;

namespace FirebirdSql.Data.FirebirdClient
{
    internal class FbClientFactory
    {
        internal DbConnection CreateConnection()
        {
            return new FbConnection();
        }
    }
}