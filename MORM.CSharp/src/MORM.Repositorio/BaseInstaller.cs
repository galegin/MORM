using MORM.Dominio.Interfaces;
using MORM.CrossCutting;
using MORM.Repositorio.Context;
using MORM.Repositorio.UnityOfWork;

namespace MORM.Repositorio
{
    public static class BaseInstaller
    {
        public static void AddRepositorio(this IAbstractContainer container)
        {
            container.Register<IAbstractDataContext, AbstractDataContext>();
            container.Register<IAbstractUnityOfWork, AbstractUnityOfWork>();
        }
    }
}