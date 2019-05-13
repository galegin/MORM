using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Repositorio.Dapper.Context;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Migrations;
using MORM.Repositorio.Tests.Ioc.Container;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class DataContextDapperTests
    {
        private readonly IAbstractDataContextDapper _dataContext;
        private readonly ITipoRepository _tipoRepository;
        private const int _cdTipo = 1;

        public DataContextDapperTests()
        {
            _dataContext = BaseContainer.Instance.Resolve<IAbstractDataContextDapper>();
            _tipoRepository = BaseContainer.Instance.Resolve<ITipoRepository>();
        }

        [TestInitialize]
        public void DataContextDapperTests_Initialize()
        {
            DataContextDapperTests_Cleanup();

            _tipoRepository.Salvar(new TipoModel { Cd_Tipo = _cdTipo });
        }

        [TestCleanup]
        public void DataContextDapperTests_Cleanup()
        {
            _tipoRepository.ClearAll();
        }

        [TestMethod]
        public void DataContextDapperTests_Migracao()
        {
            var arquivo = GetType().Assembly.Location;

            MigracaoContexto.Gerar(_dataContext, arquivo);
        }

        [TestMethod]
        public void DataContextDapperTests_Conexao()
        {
            var tipo = _tipoRepository.FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
        }
    }
}