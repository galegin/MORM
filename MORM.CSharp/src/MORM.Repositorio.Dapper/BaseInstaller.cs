using MORM.CrossCutting;
using MORM.Repositorio.Dapper.Context;

namespace MORM.Repositorio.Dapper
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IAbstractDataContextDapper, AbstractDataContextDapper>();
        }
    }
}