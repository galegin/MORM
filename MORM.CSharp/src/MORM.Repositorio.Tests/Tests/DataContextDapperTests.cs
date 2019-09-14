using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;
using MORM.Repositorio.Dapper.Context;
using MORM.Repositorio.Migrations;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class DataContextDapperTests : BaseTests
    {
        private readonly IAbstractDataContextDapper _dataContext;
        private readonly ITipoRepository _tipoRepository;
        private const int _cdTipo = 1;

        public DataContextDapperTests()
        {
            _dataContext = Resolve<IAbstractDataContextDapper>();
            _tipoRepository = Resolve<ITipoRepository>();
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
            MigracaoContexto.Gerar(_dataContext);
        }

        [TestMethod]
        public void DataContextDapperTests_Conexao()
        {
            var tipo = _tipoRepository.FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
        }
    }
}