using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class TipoServiceTests : BaseTests
    {
        private readonly ITipoService _tipoService;
        private const int _cdTipo = 1;

        public TipoServiceTests()
        {
            _tipoService = Resolve<ITipoService>();
        }        

        [TestInitialize]
        public void TipoServiceTests_Initialize()
        {
        }

        [TestCleanup]
        public void TipoServiceTests_Cleanup()
        {
        }
    }
}