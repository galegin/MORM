using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class CamposTests : BaseTests
    {
        [TestMethod]
        public void CamposTests_GetCamposFiltro()
        {
            var campos = typeof(TesteModel).GetCamposFiltro();
        }

        [TestMethod]
        public void CamposTests_GetCamposListagem()
        {
            var campos = typeof(TesteModel).GetCamposListagem();
        }

        [TestMethod]
        public void CamposTests_GetCamposPesquisa()
        {
            var campos = typeof(TesteModel).GetCamposPesquisa();
        }
    }
}