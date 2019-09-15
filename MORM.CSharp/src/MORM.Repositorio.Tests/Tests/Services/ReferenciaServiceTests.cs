using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class ReferenciaServiceTests : BaseTests
    {
        private readonly IReferenciaService _referenciaService;
        private const int _cdTipo = 1;

        public ReferenciaServiceTests()
        {
            _referenciaService = Resolve<IReferenciaService>();
        }

        [TestInitialize]
        public void ReferenciaTests_Initialize()
        {
        }

        [TestCleanup]
        public void ReferenciaTests_Cleanup()
        {
        }
    }
}