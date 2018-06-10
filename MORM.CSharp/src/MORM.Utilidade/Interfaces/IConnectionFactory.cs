using System.Data;

namespace MORM.Utilidade.Interfaces
{
    //-- galeg - 30/03/2018 15:37:52
    public interface IConnectionFactory
    {
        IDbConnection GetConnection(IAmbiente ambiente);
    }
}