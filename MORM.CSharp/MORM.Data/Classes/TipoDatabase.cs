using System;

namespace MORM.Data.Classes
{
	public enum TipoDatabase
	{
		Firebird,
		Oracle,
		MySql
	}
	
	public static class TipoDatabaseExtension
	{
		public static string GetValueData(this TipoDatabase tipoDatabase, DateTime dataTime)
		{
			return null;
		}
	}
}
