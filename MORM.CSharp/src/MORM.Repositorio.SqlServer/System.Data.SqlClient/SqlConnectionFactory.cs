namespace System.Data.SqlClient
{
    //-- galeg - 28/04/2018 20:06:14
    internal class SqlConnectionFactory
    {
        internal SqlConnection CreateConnection()
        {
            return new SqlConnection();
        }
    }
}