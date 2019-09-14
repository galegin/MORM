using MORM.Dominio.Interfaces;
using MORM.Repositorio.Mocks;
using MORM.CrossCutting;

namespace MORM.Repositorio.Tests
{
    public static class BaseInstaller
    {
        public static void AddRepositorioTests(this IAbstractContainer container)
        {
            container.Register<IAbstractDataContext, MockDataContext>();

            container.Register<ITipoRepository, TipoRepository>();
            container.Register<ITesteRepository, TesteRepository>();

            container.Register<IReferenciaService, ReferenciaService>();
            container.Register<ITesteService, TesteService>();
            container.Register<ITipoService, TipoService>();
        }
    }
}