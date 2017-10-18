/*
 * Created by SharpDevelop.
 * User: windows7
 * Date: 17/10/2017
 * Time: 20:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MORM.CSharp.Classes
{
	/// <summary>
	/// Description of TipoDatabase.
	/// </summary>
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
