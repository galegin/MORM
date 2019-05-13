using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Migrations;
using MORM.Repositorio.Tests.Ioc.Container;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class DataContextTests
    {
        private readonly IAbstractDataContext _dataContext;
        private readonly ITipoRepository _tipoRepository;
        private const int _cdTipo = 1;

        public DataContextTests()
        {
            _dataContext = BaseContainer.Instance.Resolve<IAbstractDataContext>();
            _tipoRepository = BaseContainer.Instance.Resolve<ITipoRepository>();
        }

        [TestInitialize]
        public void DataContextTests_Initialize()
        {
            DataContextTests_Cleanup();

            _tipoRepository.Salvar(new TipoModel { Cd_Tipo = _cdTipo });
        }

        [TestCleanup]
        public void DataContextTests_Cleanup()
        {
            _tipoRepository.ClearAll();
        }

        [TestMethod]
        public void DataContextTests_Migracao()
        {
            var arquivo = GetType().Assembly.Location;

            MigracaoContexto.Gerar(_dataContext, arquivo);
        }

        [TestMethod]
        public void DataContextTests_Conexao()
        {
            var tipo = _tipoRepository.FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
        }

        [TestMethod]
        public void DataContextTests_Dispose()
        {
            using (var context = BaseContainer.Instance.Resolve<IAbstractDataContext>() as IAbstractDataContext)
            {
                var lista = context.GetListaW<TipoModel>(string.Empty);
            }
        }
    }
}