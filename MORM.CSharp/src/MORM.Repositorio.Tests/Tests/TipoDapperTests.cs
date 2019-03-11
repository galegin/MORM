using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Repositorio.Dapper.Context;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Tests.IoC.Container;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    //-- galeg - 13/10/2018 12:16:29
    [TestClass]
    public class TipoDapperTests
    {
        private readonly IAbstractDataContext _dataContext;
        private readonly ITipoRepository _tipoRepository;

        public TipoDapperTests()
        {
            _dataContext = IocContainer.Instance.Resolve<IAbstractDataContextDapper>();
            _tipoRepository = new TipoRepository(_dataContext);
        }

        private const int _cdTipo = 1;
        private const string _dsTipo = "TIPO 1";

        private void IncluirTipo()
        {
            _tipoRepository.Salvar(new TipoModel(_cdTipo, _dsTipo));
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