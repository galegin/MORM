package MORM.Java.Classes;

public class Conexao
{
    public Conexao(Parametro parametro)
    {
        Parametro = parametro;
    }
    
    public Parametro Parametro;
    private Connection Connection;
    
    public DataReader GetConsulta(String sql)
    {
        Statement stm = Connection.createStatement();
        ResultSet rs = stm.executeQuery(sql);
        return rs;
    }
    
    public void ExecComando(String cmd)
    {
        Statement stm = Connection.createStatement();
		stm.execute(cmd);
    }
}