﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MORM.Dominio.Tipagens;
using MORM.Repositorio.Context;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.SqLite;
using MORM.Repositorio.Tests.Ioc.Container;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class TipoServiceTests
    {
        private readonly ITipoService _tipoService;

        public TipoServiceTests()
        {
            _tipoService = BaseContainer.Instance.Resolve<ITipoService>();
        }        

        private const int _codigoTipo = 1;

        private TipoModel GetTipo(int codigo)
        {
            return new TipoModel
            {
                Cd_Tipo = codigo,
                Ds_Tipo = $"TIPO {codigo}",
            };
        }

        [TestInitialize]
        public void TipoServiceTests_Initialize()
        {
            TipoServiceTests_Cleanup();
        }

        [TestCleanup]
        public void TipoServiceTests_Cleanup()
        {
            _tipoService.AbstractRepository.ClearAll();
        }

        [TestMethod]
        public void TipoServiceTests_Listar()
        {
            TipoServiceTests_Salvar();

            var listaDeTipo = _tipoService.AbstractRepository.ToList(x => x.Cd_Tipo == _codigoTipo);
            Assert.AreNotEqual(0, listaDeTipo.Count);
            Assert.AreEqual(_codigoTipo, listaDeTipo.FirstOrDefault().Cd_Tipo);
        }

        [TestMethod]
        public void TipoServiceTests_Consultar()
        {
            TipoServiceTests_Salvar();

            var tipo = _tipoService.AbstractRepository.FirstOrDefault(x => x.Cd_Tipo == _codigoTipo);
            Assert.IsNotNull(tipo);
            Assert.AreEqual(_codigoTipo, tipo.Cd_Tipo);
        }

        [TestMethod]
        public void TipoServiceTests_Salvar()
        {
            var tipo = GetTipo(_codigoTipo);

            _tipoService.AbstractRepository.Salvar(tipo);
        }

        [TestMethod]
        public void TipoServiceTests_Excluir()
        {
            TipoServiceTests_Salvar();

            var tipo = GetTipo(_codigoTipo);

            _tipoService.AbstractRepository.Excluir(tipo);
        }

        [TestMethod]
        public void TipoServiceTests_Ambiente()
        {
            DataContextConnection.SetConnectionFactory(TipoDatabase.SqLite, new SqLiteHelper());

            TipoServiceTests_Salvar();

            var listaDeTipo = _tipoService.AbstractRepository.ToList(x => x.Cd_Tipo == _codigoTipo);
            Assert.AreNotEqual(0, listaDeTipo.Count);
            Assert.AreEqual(_codigoTipo, listaDeTipo.FirstOrDefault().Cd_Tipo);
        }
    }
}