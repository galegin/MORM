using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Dapper.Context;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class TipoRepositoryDapperTests : BaseTests
    {
        private readonly ITipoRepositoryDapper _tipoRepository;
        private const int _cdTipo = 1;
        private const string _dsTipo = "Tipo 1";

        public TipoRepositoryDapperTests()
        {
            _tipoRepository = Resolve<ITipoRepositoryDapper>();
        }

        [TestInitialize]
        public void TipoServiceTests_Initialize()
        {
        }

        [TestCleanup]
        public void TipoServiceTests_Cleanup()
        {
        }

        [TestMethod]
        public void TipoDapperTests_Listar()
        {
            var listaDeTipo = _tipoRepository.GetAll().Where(f => f.Cd_Tipo == _cdTipo).ToList();
            Assert.AreNotEqual(0, listaDeTipo.Count);

            var tipo = listaDeTipo.FirstOrDefault();
            Assert.AreEqual(_cdTipo, tipo.Cd_Tipo);
            Assert.AreEqual(_dsTipo, tipo.Ds_Tipo);
        }

        [TestMethod]
        public void TipoDapperTests_Consultar()
        {
            var tipo = _tipoRepository.GetAll().FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
            Assert.AreEqual(_cdTipo, tipo.Cd_Tipo);
            Assert.AreEqual(_dsTipo, tipo.Ds_Tipo);
        }

        [TestMethod]
        public void TipoDapperTests_Salvar()
        {
            var tipoCons = _tipoRepository.GetAll().FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
            Assert.AreEqual(_cdTipo, tipoCons.Cd_Tipo);
            Assert.AreEqual(_dsTipo, tipoCons.Ds_Tipo);
        }

        [TestMethod]
        public void TipoDapperTests_Excluir()
        {
            _tipoRepository.Delete(new TipoModel { Cd_Tipo = _cdTipo });

            var tipoCons = _tipoRepository.GetAll().FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
            Assert.IsNull(tipoCons);
        }
    }
}