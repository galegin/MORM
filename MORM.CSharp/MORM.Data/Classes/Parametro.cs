using System.Configuration;

namespace MORM.Data.Classes
{
    public class Parametro
    {
    	public Parametro(TipoDatabase tipoDatabase, string providerName, string database, string username, string password, string hostname)
        {
            TipoDatabase = tipoDatabase; 
            ProviderName = providerName;
            Database = database;
            Username = username;
            Password = password;
            Hostname = hostname;
        }
        
    	public Parametro()
        {
            TipoDatabase = (TipoDatabase)System.Enum.Parse(typeof(TipoDatabase), ConfigurationManager.AppSettings["tipoDatabase"], false);
            ProviderName = ConfigurationManager.AppSettings["providerName"];
    		Database = ConfigurationManager.AppSettings["database"];
            Username = ConfigurationManager.AppSettings["username"];
            Password = ConfigurationManager.AppSettings["password"];
            Hostname = ConfigurationManager.AppSettings["hostname"];
        }

        public TipoDatabase TipoDatabase { get; private set; }
        public string ProviderName { get; private set; }
    	public string Database { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Hostname { get; private set; }
    }
}