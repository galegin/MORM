package MORM.Java.Classes;

import java.sql.*;
import java.text.SimpleDateFormat;

public enum TipoDatabase
{
	Firebird
	{
		@Override
		public String GetProviderName() 
		{			
			return "org.firebird.jdbc.FBDriver";
		}

		@Override
		public String GetConnectionString() 
		{			
			return "jdbc:firebirdsql:@hostname/@hostport:@database".replace("@hostport", "3050"); // 3050
		}

		@Override
		public String GetValueData(Date date) 
		{
			SimpleDateFormat fmt = new SimpleDateFormat("dd.mm.yyyy hh:mm:ss");
			return "'" + fmt.format(date) + "'";
		}
	},
	
	MySql
	{
		@Override
		public String GetProviderName() 
		{			
			return "com.mysql.jdbc.driver";
		}

		@Override
		public String GetConnectionString() 
		{			
			return "jdbc:mysql://@hostname:@hostport/@database>".replace("@hostport", "3306"); // 3306
		}

		@Override
		public String GetValueData(Date date) 
		{
			SimpleDateFormat fmt = new SimpleDateFormat("yyyy/mm/dd hh:mm:ss");
			return "'" + fmt.format(date) + "'";
		}
	},
	
	Oracle
	{
		@Override
		public String GetProviderName()
		{			
			return "oracle.jdbc.driver.OracleDriver";
		}

		@Override
		public String GetConnectionString() 
		{			
			return "jdbc:oracle:thin:@hostname:@hostport:@database".replace("@hostport", "1521"); // 1521
		}

		@Override
		public String GetValueData(Date date) 
		{
			SimpleDateFormat fmt = new SimpleDateFormat("dd/mm/yyyy hh:mm:ss");
			return "to_date('" + fmt.format(date) + "', 'DD/MM/YYYY HH24:MM:SS')";
		}
	};
	
	public abstract String GetProviderName();
	public abstract String GetConnectionString();
	public abstract String GetValueData(Date date);
}