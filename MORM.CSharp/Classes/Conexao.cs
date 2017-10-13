namespace MORM.Reppositorio.Classes
{
    public class Conexao
    {
        public Conexao(Parametro parametro)
        {
            Parametro = parametro;
        }
        
        public Parametro Parametro { get; private set; }
        
        public void ExecComando(string cmd)
        {
            var command = Connection.CreateCommand();
            command.CommandText = cmd;
            command.ExecuteNonQuery();
        }

        public DataReader GetConsulta(string sql)
        {
            var command = Connection.CreateCommand();
            command.CommandText = sql;
            return command.ExecuteReader();
        }        
    }
}