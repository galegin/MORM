using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Dapper.Context;
using MORM.Repositorio.Migrations;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class DataContextDapperTests : BaseTests
    {
        private readonly IAbstractDataContextDapper _dataContext;

        public DataContextDapperTests()
        {
            _dataContext = Resolve<IAbstractDataContextDapper>();
        }

        [TestInitialize]
        public void DataContextDapperTests_Initialize() 
        {
        }

        [TestCleanup]
        public void DataContextDapperTests_Cleanup()
        {
        }

        [TestMethod]
        public void DataContextDapperTests_MigracaoDapper()
        {
            MigracaoContexto.Gerar(_dataContext);
        }
    }
}