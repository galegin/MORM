using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Tests.IoC.Container;
using System;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class TesteServiceTests
    {
        private readonly ITesteService _testeService;

        public TesteServiceTests()
        {
            _testeService = IocContainer.Instance.Resolve<ITesteService>();
        }

        private const int _codigoTeste = 1;
        private const string _descricaoTeste = "TESTE 1";

        private TesteModel GetTeste()
        {
            return new TesteModel
            {
                Cd_Teste = _codigoTeste,
                Ds_Teste = _descricaoTeste,
                Dt_Teste = DateTime.Now,
                Nr_Teste = 2,
                In_Ativo = true,
                Vl_Teste = 3,
                Cd_Tipo = 1
            };
        }

        [TestMethod]
        public void TesteServiceTests_Listar()
        {
            TesteServiceTests_Salvar();

            var listaDeTeste = _testeService.AbstractRepository.ToList(x => x.Cd_Teste == _codigoTeste);
            Assert.AreNotEqual(0, listaDeTeste.Count);
            Assert.AreEqual(_codigoTeste, listaDeTeste.FirstOrDefault().Cd_Teste);
        }

        [TestMethod]
        public void TesteServiceTests_Consultar()
        {
            TesteServiceTests_Salvar();

            var teste = _testeService.AbstractRepository.FirstOrDefault(x => x.Cd_Teste == _codigoTeste);
            Assert.IsNotNull(teste);
            Assert.AreEqual(_codigoTeste, teste.Cd_Teste);
        }

        [TestMethod]
        public void TesteServiceTests_Salvar()
        {
            var teste = GetTeste();

            _testeService.AbstractRepository.Salvar(teste);
        }

        [TestMethod]
        public void TesteServiceTests_Excluir()
        {
            TesteServiceTests_Salvar();

            var teste = new TesteModel { Cd_Teste = 1 };

            _testeService.AbstractRepository.Excluir(teste);
        }
    }
}