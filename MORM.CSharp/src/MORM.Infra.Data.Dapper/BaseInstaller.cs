using MORM.Dominio.Interfaces;
using MORM.Infra.CrossCutting;
using MORM.Infra.Data.Dapper.Context;

namespace MORM.Infra.Data.Dapper
{
    public class BaseInstaller
    {
        static BaseInstaller()
        {
            Install(AbstractContainer.Instance);
        }

        public static IAbstractContainer Container =>
            AbstractContainer.Instance;

        public static void Install(IAbstractContainer container)
        {
            container.Register<IAbstractDataContextDapper, AbstractDataContextDapper>();
        }
    }
}