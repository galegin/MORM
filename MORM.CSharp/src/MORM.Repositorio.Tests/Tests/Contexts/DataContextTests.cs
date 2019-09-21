using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Migrations;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class DataContextTests : BaseTests
    {
        private readonly IMigracaoEntRepository _repository;
        private readonly IMigracao _migracao;

        public DataContextTests()
        {
            _repository = Resolve<IMigracaoEntRepository>();
            _migracao = Resolve<IMigracao>();
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
            MigracaoContexto.Gerar(_repository, _migracao);
        }
    }
}