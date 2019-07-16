using MORM.Dominio.Interfaces;
using MORM.Infra.Data.Dapper.Context;

namespace MORM.Infra.Data.Dapper
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IAbstractDataContextDapper, AbstractDataContextDapper>();
        }
    }
}