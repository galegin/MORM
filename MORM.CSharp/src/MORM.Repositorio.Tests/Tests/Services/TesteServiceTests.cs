using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class TesteServiceTests : BaseTests
    {
        private readonly ITesteService _testeService;
        private const int _cdTeste = 1;

        public TesteServiceTests()
        {
            _testeService = Resolve<ITesteService>();
        }

        [TestInitialize]
        public void TesteServiceTests_Initialize()
        {
        }

        [TestCleanup]
        public void TesteServiceTests_Cleanup()
        {
        }
    }
}