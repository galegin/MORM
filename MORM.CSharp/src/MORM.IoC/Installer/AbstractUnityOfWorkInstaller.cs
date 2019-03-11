using MORM.Repositorio.IoC;

namespace MORM.IoC.Installer
{
    public class AbstractUnityOfWorkInstaller : AbstractInstaller
    {
        protected override void Setup()
        {
            Register<IAbstractUnityOfWork, AbstractUnityOfWork>();
        }
    }
}

/*
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web;
using VirtualWebService.Repository;
using VirtualWebService.RepositoryInterfaces;
using VirtualWebService.Utils;

namespace VirtualWebService.IoC.Installers
{
    public class UnitOfWorkInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWorkConsulta>().UsingFactoryMethod(GetUoWConsulta).LifestylePerWebRequest());
            container.Register(Component.For<IUnitOfWorkGravacao>().UsingFactoryMethod(GetUoWGravacao).LifestylePerWebRequest());
        }

        private UnitOfWorkConsulta GetUoWConsulta()
        {
            var credencial = HeaderCredenciais.GetFromRequest();
            return new UnitOfWorkConsulta(credencial.Usuario, credencial.Senha);
        }

        private UnitOfWorkGravacao GetUoWGravacao()
        {
            var credencial = HeaderCredenciais.GetFromRequest();
            return new UnitOfWorkGravacao(credencial.Usuario, credencial.Senha);
        }
    }
} 
*/
