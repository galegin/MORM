package MORM.Java.Classes;

public class Parametro
{
    public Parametro(String database, String username, String password, String hostname)
    {
        Database = database;
        Username = username;
        Password = password;
        Hostname = hostname;        
    }
    
    public String Database;
    public String Username;
    public String Password;
    public String Hostname;
}