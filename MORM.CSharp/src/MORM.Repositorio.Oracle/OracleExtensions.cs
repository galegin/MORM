namespace MORM.Repositorio.Oracle
{
    public static class OracleExtensions
    {
        public static string GetConexaoSemTnsNames(this string hostname, int hostport, string database, string username, string password)
        {
            return 
                $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                $"(HOST={hostname})(PORT={hostport}))(CONNECT_DATA=(SERVICE_NAME={database})));"+
                $"User Id={username};Password={password};";
        }
    }
}