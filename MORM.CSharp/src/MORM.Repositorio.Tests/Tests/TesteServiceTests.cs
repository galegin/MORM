using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;
using System;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class TesteServiceTests : BaseTests
    {
        private readonly ITesteService _testeService;

        public TesteServiceTests()
        {
            _testeService = Resolve<ITesteService>();
        }

        private const int _codigoTeste = 1;

        private TesteModel GetTeste(int codigo)
        {
            return new TesteModel
            {
                Cd_Teste = codigo,
                Ds_Teste = $"TESTE {codigo}",
                Dt_Teste = DateTime.Now,
                Nr_Teste = 2,
                In_Ativo = true,
                Vl_Teste = 3,
                Cd_Tipo = 1
            };
        }

        [TestInitialize]
        public void TesteServiceTests_Initialize()
        {
            TesteServiceTests_Cleanup();
        }

        [TestCleanup]
        public void TesteServiceTests_Cleanup()
        {
            _testeService.AbstractRepository.ClearAll();
        }

        [TestMethod]
        public void TesteServiceTests_Listar()
        {
            TesteServiceTests_Salvar();

            var listaDeTeste = _testeService.AbstractRepository.ToList();
            Assert.AreNotEqual(0, listaDeTeste.Count);
        }

        [TestMethod]
        public void TesteServiceTests_Consultar()
        {
            TesteServiceTests_Salvar();

            var teste = _testeService.AbstractRepository.ToList().FirstOrDefault(x => x.Cd_Teste == _codigoTeste);
            Assert.AreEqual(_codigoTeste, teste.Cd_Teste);
        }

        [TestMethod]
        public void TesteServiceTests_Salvar()
        {
            var teste = GetTeste(_codigoTeste);

            _testeService.AbstractRepository.Salvar(teste);
        }

        [TestMethod]
        public void TesteServiceTests_Excluir()
        {
            TesteServiceTests_Salvar();

            var teste = new TesteModel { Cd_Teste = _codigoTeste };

            _testeService.AbstractRepository.Excluir(teste);
        }
    }
}