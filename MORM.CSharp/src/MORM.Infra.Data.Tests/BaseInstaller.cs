using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Infra.Data.UnityOfWork;
using MORM.Infra.Mocks;
using MORM.Infra.Data.Dapper.Context;
using MORM.Infra.CrossCutting;

namespace MORM.Infra.Data.Tests
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IAmbiente, Ambiente>();
            container.Register<IEmpresa, Empresa>();
            container.Register<ITerminal, Terminal>();
            container.Register<IUsuario, Usuario>();

            container.Register<IAbstractDataContext, MockDataContext>();
            container.Register<IAbstractDataContextDapper, AbstractDataContextDapper>();

            container.Register<ITipoRepository, TipoRepository>();
            container.Register<ITesteRepository, TesteRepository>();

            container.Register<IReferenciaService, ReferenciaService>();
            container.Register<ITesteService, TesteService>();
            container.Register<ITipoService, TipoService>();

            container.Register<IAbstractUnityOfWork, AbstractUnityOfWork>();
        }
    }
}