package MORM.Java.Classes;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class Conexao
{
    public Conexao(Parametro parametro)
    {
        Parametro = parametro;
        
        ConnectionString = 
        	ProviderFactory.GetConnectionStringByProvider(parametro.ProviderName)
        	.replace("@database", parametro.Database)
        	.replace("@username", parametro.Username)
        	.replace("@password", parametro.Password)
        	.replace("@hostname", parametro.Hostname);
        
        Connection = ProviderFactory.CreateConnection(parametro.ProviderName, ConnectionString, parametro.Username, parametro.Password);
        //Connection.open();
    }
    
    public Parametro Parametro;
    public String ConnectionString; 
    public Connection Connection;
    
    public ResultSet GetConsulta(String sql)
    {
    	ResultSet resultSet = null;
		try {
			Statement stm = Connection.createStatement();
			resultSet = stm.executeQuery(sql);
		} catch (SQLException e) {
			e.printStackTrace();
		}
		return resultSet;
    }
    
    public void ExecComando(String cmd)
    {
		try {
			Statement stm = Connection.createStatement();
			stm.execute(cmd);
		} catch (SQLException e) {
			e.printStackTrace();
		}
    }
}