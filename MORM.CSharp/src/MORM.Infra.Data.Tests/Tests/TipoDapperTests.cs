using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Infra.Data.Dapper.Context;
using System.Linq;

namespace MORM.Infra.Data.Tests
{
    [TestClass]
    public class TipoDapperTests
    {
        private readonly IAbstractDataContext _dataContext;
        private readonly ITipoRepository _tipoRepository;

        public TipoDapperTests()
        {
            _dataContext = BaseInstaller.Container.Resolve<IAbstractDataContextDapper>();
            _tipoRepository = new TipoRepository(_dataContext);
        }

        private const int _cdTipo = 1;
        private const string _dsTipo = "TIPO 1";

        private void IncluirTipo()
        {
            _tipoRepository.Salvar(new TipoModel(_cdTipo, _dsTipo));
        }

        [TestInitialize]
        public void TipoServiceTests_Initialize()
        {
            TipoServiceTests_Cleanup();
        }

        [TestCleanup]
        public void TipoServiceTests_Cleanup()
        {
            _tipoRepository.ClearAll();
        }

        [TestMethod]
        public void TipoDapperTests_Listar()
        {
            IncluirTipo();

            var listaDeTipo = _tipoRepository.ToList(f => f.Cd_Tipo == _cdTipo);
            Assert.AreNotEqual(0, listaDeTipo.Count);

            var tipo = listaDeTipo.FirstOrDefault();
            Assert.AreEqual(_cdTipo, tipo.Cd_Tipo);
            Assert.AreEqual(_dsTipo, tipo.Ds_Tipo);
        }

        [TestMethod]
        public void TipoDapperTests_Consultar()
        {
            IncluirTipo();

            var tipo = _tipoRepository.FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
            Assert.AreEqual(_cdTipo, tipo.Cd_Tipo);
            Assert.AreEqual(_dsTipo, tipo.Ds_Tipo);
        }

        [TestMethod]
        public void TipoDapperTests_Salvar()
        {
            IncluirTipo();

            var tipoCons = _tipoRepository.FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
            Assert.AreEqual(_cdTipo, tipoCons.Cd_Tipo);
            Assert.AreEqual(_dsTipo, tipoCons.Ds_Tipo);
        }

        [TestMethod]
        public void TipoDapperTests_Excluir()
        {
            IncluirTipo();

            _tipoRepository.Excluir(new TipoModel { Cd_Tipo = _cdTipo });

            var tipoCons = _tipoRepository.FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
            Assert.AreNotEqual(_cdTipo, tipoCons.Cd_Tipo);
            Assert.AreNotEqual(_dsTipo, tipoCons.Ds_Tipo);
        }
    }
}