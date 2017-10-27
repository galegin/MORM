package MORM.Java.Classes;

import java.sql.Connection;
import java.sql.DriverManager;

public class ProviderFactory
{
	public static String GetConnectionStringByProvider(String providerName)
	{
		String connectionString = null;
		for (TipoDatabase tipoDatabase : TipoDatabase.values())
			if (tipoDatabase.GetProviderName().equals(providerName))
				connectionString = tipoDatabase.GetConnectionString();
		return connectionString;
	}
	
	public static Connection CreateConnection(
		String providerName, String connectionString, String username, String password)
	{
		Connection connection = null;
		try {
			Class.forName(providerName);
			connection = DriverManager.getConnection(connectionString, username, password);
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		} catch (Exception e) {
			e.printStackTrace();
		}		
		return connection;
	}
}
