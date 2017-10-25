using System;
using System.Configuration;
using System.Data.Common;

namespace MORM.Data.Classes
{
    public static class ProviderFactory
    {
        public static string GetConnectionStringByProvider(string providerName)
        {
            // Return null on failure.
            string returnValue = null;
        
            // Get the collection of connection strings.
            ConnectionStringSettingsCollection settings =
                ConfigurationManager.ConnectionStrings;
        
            // Walk through the collection and return the first 
            // connection string matching the providerName.
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    if (cs.ProviderName == providerName)
                    {
                        returnValue = cs.ConnectionString;
                        break;
                    }
                }
            }
            
            return returnValue;
        }
        
        public static DbConnection CreateDbConnection(
            string providerName, string connectionString)
        {
            // Assume failure.
            DbConnection connection = null;
        
            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);
        
                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (connection != null)
                        connection = null;
                    Console.WriteLine(ex.Message);
                }
            }

            // Return the connection.
            return connection;
        }
    }
}