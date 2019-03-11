﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Utilidade.Extensoes;

namespace MORM.Repositorio.Tests
{
    //-- galeg - 13/10/2018 12:23:46
    [TestClass]
    public class CamposTests
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