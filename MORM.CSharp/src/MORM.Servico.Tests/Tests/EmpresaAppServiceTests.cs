using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.CrossCutting;
using MORM.Servico.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Servico.Tests
{
    [TestClass]
    public class EmpresaAppServiceTests : BaseTests
    {
        private readonly IEmpresaAppService _empresaAppService;
        private const int _idEmpresa = 1;
        private const string _cdEmpresa = "1";
        private const string _dsEmpresa = "Empresa 1";
        private const string _dsEmpresaAlterada = "Empresa 1 Alterada";

        public EmpresaAppServiceTests()
        {
            _empresaAppService = Resolve<IEmpresaAppService>();
        }

        public void Incluir()
        {
            var empresa = new Empresa
            {
                Id_Empresa = _idEmpresa,
                Cd_Empresa = _cdEmpresa,
                Ds_Empresa = _dsEmpresa,
            };
            _empresaAppService.Salvar(empresa);
        }

        public void Excluir()
        {
            var empresa = new Empresa { Id_Empresa = _idEmpresa };
            _empresaAppService.Excluir(empresa);
        }

        [TestMethod]
        public void EmpresaAppServiceTests_Listar()
        {
            Incluir();

            var empresa = new Empresa { Id_Empresa = _idEmpresa };
            var empresaLista = _empresaAppService.Listar(empresa) as IList<Empresa>;
            Assert.AreNotEqual(0, empresaLista.Count);

            var empresaRet = empresaLista.FirstOrDefault();
            Assert.AreEqual(_idEmpresa, empresaRet.Id_Empresa);
        }

        [TestMethod]
        public void EmpresaAppServiceTests_Consultar()
        {
            Incluir();

            var empresa = new Empresa { Id_Empresa = _idEmpresa };
            var empresaRet = _empresaAppService.Consultar(empresa) as Empresa;
            Assert.AreEqual(_idEmpresa, empresaRet.Id_Empresa);
        }

        [TestMethod]
        public void EmpresaAppServiceTests_Incluir()
        {
            Excluir();

            var empresa = new Empresa
            {
                Id_Empresa = _idEmpresa,
                Cd_Empresa = _cdEmpresa,
                Ds_Empresa = _dsEmpresa,
            };
            _empresaAppService.Incluir(empresa);

            var empresaFiltro = new Empresa { Id_Empresa = _idEmpresa };
            var empresaRet = _empresaAppService.Consultar(empresaFiltro) as Empresa;
            Assert.AreEqual(_idEmpresa, empresaRet.Id_Empresa);
            Assert.AreEqual(_cdEmpresa, empresaRet.Cd_Empresa);
            Assert.AreEqual(_dsEmpresa, empresaRet.Ds_Empresa);
        }

        [TestMethod]
        public void EmpresaAppServiceTests_Alterar()
        {
            var empresa = new Empresa
            {
                Id_Empresa = _idEmpresa,
                Ds_Empresa = _dsEmpresaAlterada,
            };
            _empresaAppService.Alterar(empresa);

            var empresaFiltro = new Empresa { Id_Empresa = _idEmpresa };
            var empresaRet = _empresaAppService.Consultar(empresaFiltro) as Empresa;
            Assert.AreEqual(_idEmpresa, empresaRet.Id_Empresa);
            Assert.AreEqual(_dsEmpresaAlterada, empresaRet.Ds_Empresa);
        }

        [TestMethod]
        public void EmpresaAppServiceTests_Salvar()
        {
            var empresa = new Empresa
            {
                Id_Empresa = _idEmpresa,
                Cd_Empresa = _cdEmpresa,
                Ds_Empresa = _dsEmpresa,
            };
            _empresaAppService.Salvar(empresa);

            var empresaFiltro = new Empresa { Id_Empresa = _idEmpresa };
            var empresaRet = _empresaAppService.Consultar(empresaFiltro) as Empresa;
            Assert.AreEqual(_idEmpresa, empresaRet.Id_Empresa);
            Assert.AreEqual(_cdEmpresa, empresaRet.Cd_Empresa);
            Assert.AreEqual(_dsEmpresa, empresaRet.Ds_Empresa);
        }

        [TestMethod]
        public void EmpresaAppServiceTests_Excluir()
        {
            var empresa = new Empresa { Id_Empresa = _idEmpresa };
            _empresaAppService.Excluir(empresa);

            var empresaFiltro = new Empresa { Id_Empresa = _idEmpresa };
            var empresaRet = _empresaAppService.Consultar(empresaFiltro) as Empresa;
            Assert.IsNull(empresaRet);
        }

        [TestMethod]
        public void EmpresaAppServiceTests_Sequencia()
        {
            var empresa = new Empresa { Id_Empresa = _idEmpresa };
            var empresaRet = (long)_empresaAppService.Sequencia(empresa);
            Assert.AreNotEqual(0, empresaRet);
        }
    }
}