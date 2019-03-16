using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Repositorio.Context;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Migrations;
using MORM.Repositorio.Tests.Ioc.Container;
using MORM.Utilidade.Entidades;

namespace MORM.Repositorio.Tests
{
    //-- galeg - 13/10/2018 12:16:29
    [TestClass]
    public class DataContextTests
    {
        private readonly IAbstractDataContext _dataContext;
        private readonly ITipoRepository _tipoRepository;

        public DataContextTests()
        {
            _dataContext = AbstractIocContainer.Instance.Resolve<IAbstractDataContext>();
            _tipoRepository = AbstractIocContainer.Instance.Resolve<ITipoRepository>();
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
            using (var context = AbstractIocContainer.Instance.Resolve<IAbstractDataContext>() as AbstractDataContext)
            {
                var lista = context.GetListaW<TipoModel>(string.Empty);
            }
        }
    }
}