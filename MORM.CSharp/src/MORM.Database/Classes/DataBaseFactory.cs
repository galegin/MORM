using MORM.Repositorio.Extensions;
using MORM.Dominio.Interfaces;
using System;
using System.Configuration;
using System.Reflection;

namespace MORM.Repositorio
{
    public sealed class DataBaseFactory
    {
        public static DbFactorySectionHandler sectionHandler = 
            (DbFactorySectionHandler)ConfigurationManager.GetSection("DbFactoryConfiguration");

        private DataBaseFactory() { }

        public static DataBase CreateDataBase(IAmbiente ambiente)
        {
            if (sectionHandler?.Name?.Length == 0)
                throw new Exception("Database name not defined in DbFactoryConfiguration section of config file");

            try
            {
                Type database = Type.GetType(sectionHandler.Name);
                ConstructorInfo constructorInfo = database.GetConstructor(new Type[] { });
                DataBase databaseObj = (DataBase)constructorInfo.Invoke(null);
                databaseObj.connectionString = ambiente.GetConnectionString(sectionHandler.ConnectionString);
                return databaseObj;
            }
            catch (Exception excep)
            {
                throw new Exception("Error instantiating database " + sectionHandler.Name + ". " + excep.Message);
            }
        }
    }
}