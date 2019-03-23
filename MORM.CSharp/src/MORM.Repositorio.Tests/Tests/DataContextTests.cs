using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Repositorio.Context;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Migrations;
using MORM.Repositorio.Tests.Ioc.Container;
using MORM.Dominio.Entidades;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class DataContextTests
    {
        private readonly IAbstractDataContext _dataContext;
        private readonly ITipoRepository _tipoRepository;

        public DataContextTests()
        {
            _dataContext = BaseContainer.Instance.Resolve<IAbstractDataContext>();
            _tipoRepository = BaseContainer.Instance.Resolve<ITipoRepository>();
        }

        [TestMethod]
        public void DbContextTests_Migracao()
        {
            var arquivo = GetType().Assembly.Location;

            MigracaoContexto.Gerar(_dataContext, arquivo);
        }

        [TestMethod]
        public void DbContextTests_Conexao()
        {
            var tipo = _tipoRepository.FirstOrDefault(f => f.Cd_Tipo == 1);
        }

        [TestMethod]
        public void DbContextTests_Dispose()
        {
            using (var context = BaseContainer.Instance.Resolve<IAbstractDataContext>() as AbstractDataContext)
            {
                var lista = context.GetListaW<TipoModel>(string.Empty);
            }
        }
    }
}