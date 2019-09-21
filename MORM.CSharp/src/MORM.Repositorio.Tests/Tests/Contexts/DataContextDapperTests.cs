using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Migrations;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class DataContextDapperTests : BaseTests
    {
        private readonly IMigracaoEntRepository _repository;
        private readonly IMigracao _migracao;

        public DataContextDapperTests()
        {
            _repository = Resolve<IMigracaoEntRepository>();
            _migracao = Resolve<IMigracao>();
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
            MigracaoContexto.Gerar(_repository, _migracao);
        }
    }
}