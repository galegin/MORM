using MORM.CrossCutting;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Context;
using MORM.Repositorio.Dapper.Context;

namespace MORM.Repositorio.Tests
{
    public static class BaseInstaller
    {
        public static void AddRepositorioTests(this IAbstractContainer container)
        {
            container.Register<IAbstractDataContext, AbstractDataContext>();
            container.Register<IAbstractDataContextDapper, AbstractDataContextDapper>();

            container.Register<IReferenciaRepository, ReferenciaRepository>();
            container.Register<ITipoRepository, TipoRepository>();
            container.Register<ITesteRepository, TesteRepository>();

            container.Register<ITipoRepositoryContext, TipoRepositoryContext>();
            container.Register<ITipoRepositoryContextDapper, TipoRepositoryContextDapper>();

            container.Register<IReferenciaService, ReferenciaService>();
            container.Register<ITesteService, TesteService>();
            container.Register<ITipoService, TipoService>();
        }
    }
}