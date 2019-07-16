using MORM.Dominio.Interfaces;
using MORM.Infra.Data.Context;
using MORM.Infra.Data.UnityOfWork;

namespace MORM.Infra.Data
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IAbstractDataContext, AbstractDataContext>();
            container.Register<IAbstractUnityOfWork, AbstractUnityOfWork>();
        }
    }
}