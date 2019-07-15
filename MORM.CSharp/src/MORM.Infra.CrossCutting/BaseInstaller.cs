using MORM.Dominio.Interfaces;

namespace MORM.Infra.CrossCutting
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
        }
    }
}