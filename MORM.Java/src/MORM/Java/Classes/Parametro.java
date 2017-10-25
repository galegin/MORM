package MORM.Java.Classes;

public class Parametro
{
    public Parametro(TipoDatabase tipoDatabase, String providerName, String database, String username, String password, String hostname)
    {
    	TipoDatabase = tipoDatabase;
    	ProviderName = providerName; 
        Database = database;
        Username = username;
        Password = password;
        Hostname = hostname;        
    }
    
    public TipoDatabase TipoDatabase;
    public String ProviderName;
    public String Database;
    public String Username;
    public String Password;
    public String Hostname;
}