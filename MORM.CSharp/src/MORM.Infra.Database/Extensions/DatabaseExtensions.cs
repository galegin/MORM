using MORM.Dominio.Interfaces;
using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace MORM.Infra.Database.Extensions
{
	public static class DatabaseExtensions
	{
		public static IDbConnection GetConnection(this IAmbiente ambiente)
		{
            /*
			Assembly assembly = Assembly.LoadFrom("MyNice.dll");
			Type type = assembly.GetType("MyType");
			object instanceOfMyType = Activator.CreateInstance(type);
			*/

            var pathDriverAssembly = Path.Combine("Drivers", ambiente.TipoDatabase.ToString());
            var pathDriver = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pathDriverAssembly);
            PathExtensions.SetPath(pathDriver);

            var nomeAssembly = Path.Combine(pathDriver, ambiente.TipoDatabase.GetNomeAssembly());
			var assembly = Assembly.LoadFrom(nomeAssembly);

            var nomeType = ambiente.TipoDatabase.GetNomeType();
			var type = assembly.GetType(nomeType);

            var connection = (IDbConnection)Activator.CreateInstance(type);
			connection.ConnectionString = ambiente.GetConnectionString();

            return connection;
		}
	}
}