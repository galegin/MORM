using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class TesteRepositoryTests : BaseTests
    {
        private readonly ITesteRepository _testeRepository;
        private const int _cdTeste = 1;
        private const string _dsTeste = "Teste";

        public TesteRepositoryTests()
        {
            _testeRepository = Resolve<ITesteRepository>();
        }

        [TestInitialize]
        public void TesteServiceTests_Initialize()
        {
        }

        [TestCleanup]
        public void TesteServiceTests_Cleanup()
        {
        }

        [TestMethod]
        public void TesteServiceTests_Listar()
        {
            TesteServiceTests_Salvar();

            var listaDeTeste = _testeRepository.GetAll().ToList();
            Assert.AreNotEqual(0, listaDeTeste.Count);
        }

        [TestMethod]
        public void TesteServiceTests_Consultar()
        {
            TesteServiceTests_Salvar();

            var teste = _testeRepository.GetAll().FirstOrDefault(x => x.Cd_Teste == _cdTeste);
            Assert.AreEqual(_cdTeste, teste.Cd_Teste);
        }

        [TestMethod]
        public void TesteServiceTests_Salvar()
        {
            var teste = new TesteModel
            {
                Cd_Teste = _cdTeste,
                Ds_Teste = _dsTeste,
            };

            _testeRepository.AddOrUpdate(teste);
        }

        [TestMethod]
        public void TesteServiceTests_Excluir()
        {
            TesteServiceTests_Salvar();

            var teste = new TesteModel { Cd_Teste = _cdTeste };

            _testeRepository.Delete(teste);
        }
    }
}