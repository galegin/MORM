using System.Data.Common;

namespace FirebirdSql.Data.FirebirdClient
{
    //-- galeg - 30/03/2018 17:11:00
    internal class FbClientFactory
    {
        internal DbConnection CreateConnection()
        {
            return new FbConnection();
        }
    }
}