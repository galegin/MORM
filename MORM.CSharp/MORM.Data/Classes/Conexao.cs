using System.Data.Common;

namespace MORM.Data.Classes
{
    public class Conexao
    {
        public Conexao(Parametro parametro)
        {
            Parametro = parametro;
            
            ConnectionString = 
                ProviderFactory.GetConnectionStringByProvider(parametro.ProviderName)
                .Replace("@database", parametro.Database)
                .Replace("@username", parametro.Username)
                .Replace("@password", parametro.Password)
                .Replace("@hostname", parametro.Hostname);
            
            Connection = ProviderFactory.CreateDbConnection(parametro.ProviderName, ConnectionString);
            Connection.Open();    
        }
        
        public Parametro Parametro { get; private set; }
        public string ConnectionString { get; private set; }
        public DbConnection Connection { get; private set; }
        
        public void ExecComando(string cmd)
        {
            var command = Connection.CreateCommand();
            command.CommandText = cmd;
            command.ExecuteNonQuery();
        }

        public DbDataReader GetConsulta(string sql)
        {
            var command = Connection.CreateCommand();
            command.CommandText = sql;
            return command.ExecuteReader();
        }        
    }
}