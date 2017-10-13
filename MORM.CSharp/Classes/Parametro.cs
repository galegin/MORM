namespace MORM.Reppositorio.Classes
{
    public class Parametro
    {
        public Parametro(string database, string username, string password, string hostname)
        {
            Database = database;
            Username = username;
            Password = password;
            Hostname = hostname;
        }
        
        public string Database { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Hostname { get; private set; }
    }
}