using MORM.Dominio.Interfaces;
using MORM.Infra.CrossCutting;
using MORM.Infra.Data.Context;
using MORM.Infra.Data.UnityOfWork;

namespace MORM.Infra.Data
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
            container.Register<IAbstractDataContext, AbstractDataContext>();
            container.Register<IAbstractUnityOfWork, AbstractUnityOfWork>();

            Dominio.BaseInstaller.Install(container);
        }
    }
}