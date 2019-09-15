using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class TipoRepositoryTests : BaseTests
    {
        private readonly ITipoRepository _tipoRepository;
        private const int _cdTipo = 1;
        private const string _dsTipo = "Tipo";

        public TipoRepositoryTests()
        {
            _tipoRepository = Resolve<ITipoRepository>();
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
        public void TipoServiceTests_Listar()
        {
            TipoServiceTests_Salvar();

            var listaDeTipo = _tipoRepository.GetAll().Where(x => x.Cd_Tipo == _cdTipo).ToList();
            Assert.AreNotEqual(0, listaDeTipo.Count);
            Assert.AreEqual(_cdTipo, listaDeTipo.FirstOrDefault().Cd_Tipo);
        }

        [TestMethod]
        public void TipoServiceTests_Consultar()
        {
            TipoServiceTests_Salvar();

            var tipo = _tipoRepository.GetAll().FirstOrDefault(x => x.Cd_Tipo == _cdTipo);
            Assert.IsNotNull(tipo);
            Assert.AreEqual(_cdTipo, tipo.Cd_Tipo);
        }

        [TestMethod]
        public void TipoServiceTests_Salvar()
        {
            var tipo = new TipoModel
            {
                Cd_Tipo = _cdTipo,
                Ds_Tipo = _dsTipo,
            };

            _tipoRepository.AddOrUpdate(tipo);
        }

        [TestMethod]
        public void TipoServiceTests_Excluir()
        {
            TipoServiceTests_Salvar();

            var tipo = new TipoModel { Cd_Tipo = _cdTipo, };

            _tipoRepository.Delete(tipo);
        }

        [TestMethod]
        public void TipoServiceTests_Ambiente()
        {
            TipoServiceTests_Salvar();

            var listaDeTipo = _tipoRepository.GetAll().Where(x => x.Cd_Tipo == _cdTipo).ToList();
            Assert.AreNotEqual(0, listaDeTipo.Count);
            Assert.AreEqual(_cdTipo, listaDeTipo.FirstOrDefault().Cd_Tipo);
        }
    }
}