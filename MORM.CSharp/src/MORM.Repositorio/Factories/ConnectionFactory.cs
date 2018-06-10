using MORM.Utilidade.Interfaces;
using System.Data;

namespace MORM.Repositorio.Factories
{
    //-- galeg - 30/03/2018 16:09:46
    public class ConnectionFactory : IConnectionFactory
    {
        private string GetConnectionString(IAmbiente ambiente)
        {
            return ProviderFactory.GetConnectionString(ambiente.ProviderName)
                .Replace("@database", ambiente.Database)
                .Replace("@username", ambiente.Username)
                .Replace("@password", ambiente.Password)
                .Replace("@hostname", ambiente.Hostname);
        }

        public IDbConnection GetConnection(IAmbiente ambiente)
        {
            var connectionString = GetConnectionString(ambiente);

            return ProviderFactory.GetConnection(ambiente.ProviderName, connectionString);
        }
    }
}