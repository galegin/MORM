namespace System.Data.SqlClient
{
    internal class SqlConnectionFactory
    {
        internal SqlConnection CreateConnection()
        {
            return new SqlConnection();
        }
    }
}