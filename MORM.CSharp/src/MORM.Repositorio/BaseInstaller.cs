using MORM.Dominio.Interfaces;
using MORM.CrossCutting;
using MORM.Repositorio.Context;
using MORM.Repositorio.UnityOfWork;

namespace MORM.Repositorio
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