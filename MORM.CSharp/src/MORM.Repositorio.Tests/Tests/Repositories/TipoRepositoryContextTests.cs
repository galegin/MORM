using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class TipoRepositoryContextTests : BaseTests
    {
        private readonly ITipoRepositoryContext _tipoRepository;
        private const int _cdTipo = 1;
        private const string _dsTipo = "Tipo 1";

        public TipoRepositoryContextTests()
        {
            _tipoRepository = Resolve<ITipoRepositoryContext>();
        }

        [TestInitialize]
        public void TipoRepositoryContextTests_Initialize()
        {
        }

        [TestCleanup]
        public void TipoRepositoryContextTests_Cleanup()
        {
        }

        [TestMethod]
        public void TipoDapperTests_Listar()
        {
            TipoDapperTests_Salvar();

            var listaDeTipo = _tipoRepository.GetAll().Where(f => f.Cd_Tipo == _cdTipo).ToList();
            Assert.AreNotEqual(0, listaDeTipo.Count);

            var tipo = listaDeTipo.FirstOrDefault();
            Assert.AreEqual(_cdTipo, tipo.Cd_Tipo);
            Assert.AreEqual(_dsTipo, tipo.Ds_Tipo);
        }

        [TestMethod]
        public void TipoDapperTests_Consultar()
        {
            TipoDapperTests_Salvar();

            var tipo = _tipoRepository.GetAll().FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
            Assert.AreEqual(_cdTipo, tipo.Cd_Tipo);
            Assert.AreEqual(_dsTipo, tipo.Ds_Tipo);
        }

        [TestMethod]
        public void TipoDapperTests_Salvar()
        {
            var tipo = new TipoModel
            {
                Cd_Tipo = _cdTipo,
                Ds_Tipo = _dsTipo,
            };
            _tipoRepository.AddOrUpdate(tipo);

            var tipoCons = _tipoRepository.GetAll().FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
            Assert.AreEqual(_cdTipo, tipoCons.Cd_Tipo);
            Assert.AreEqual(_dsTipo, tipoCons.Ds_Tipo);
        }

        [TestMethod]
        public void TipoDapperTests_Excluir()
        {
            TipoDapperTests_Salvar();

            _tipoRepository.Delete(new TipoModel { Cd_Tipo = _cdTipo });

            var tipoCons = _tipoRepository.GetAll().FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
            Assert.IsNull(tipoCons);
        }
    }
}