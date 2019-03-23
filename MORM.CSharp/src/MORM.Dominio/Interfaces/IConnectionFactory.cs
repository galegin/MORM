using System.Data;

namespace MORM.Dominio.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection(IAmbiente ambiente);
    }
}