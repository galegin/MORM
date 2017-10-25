package MORM.Java.Classes;

import java.sql.*;
import java.text.SimpleDateFormat;

public enum TipoDatabase
{
	Firebird
	{
		@Override
		public String GetValueData(Date date) 
		{
			SimpleDateFormat fmt = new SimpleDateFormat("dd.mm.yyyy hh:mm:ss");
			return "'" + fmt.format(date) + "'";
		}
	},
	
	Oracle
	{
		@Override
		public String GetValueData(Date date) 
		{
			SimpleDateFormat fmt = new SimpleDateFormat("dd/mm/yyyy hh:mm:ss");
			return "to_date('" + fmt.format(date) + "', 'DD/MM/YYYY HH24:MM:SS')";
		}
	},
	
	MySql
	{
		@Override
		public String GetValueData(Date date) 
		{
			SimpleDateFormat fmt = new SimpleDateFormat("yyyy/mm/dd hh:mm:ss");
			return "'" + fmt.format(date) + "'";
		}
	};
	
	public abstract String GetValueData(Date date);
}