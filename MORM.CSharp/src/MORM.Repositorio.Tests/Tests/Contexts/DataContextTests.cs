using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Migrations;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class DataContextTests : BaseTests
    {
        private readonly IAbstractDataContext _dataContext;

        public DataContextTests()
        {
            _dataContext = Resolve<IAbstractDataContext>();
        }

        [TestInitialize]
        public void DataContextTests_Initialize()
        {
        }

        [TestCleanup]
        public void DataContextTests_Cleanup()
        {
        }

        [TestMethod]
        public void DataContextTests_Migracao()
        {
            MigracaoContexto.Gerar(_dataContext);
        }
    }
}