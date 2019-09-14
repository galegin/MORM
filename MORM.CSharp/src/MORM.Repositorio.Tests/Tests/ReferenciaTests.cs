using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class ReferenciaTests : BaseTests
    {
        private readonly IReferenciaService _referenciaService;
        private readonly ITesteService _testeService;
        private readonly TipoEnum _tipoEnum = TipoEnum.Normal;
        private const int _cdTipo = 1;

        public ReferenciaTests()
        {
            _referenciaService = Resolve<IReferenciaService>();
            _testeService = Resolve<ITesteService>();
        }

        [TestInitialize]
        public void ReferenciaTests_Initialize()
        {
            ReferenciaTests_Cleanup();

            var referenciaModel = new ReferenciaModel()
            {
                Tipo = new TipoModel { Cd_Tipo = _cdTipo },
                Teste = new TesteModel { Cd_Tipo = _cdTipo }
            };
            _referenciaService.Salvar(referenciaModel);

            var testeModel = new TesteModel()
            {
                Tipo = new TipoModel { Cd_Tipo = _cdTipo }
            };
            _testeService.Salvar(testeModel);
        }

        [TestCleanup]
        public void ReferenciaTests_Cleanup()
        {
            _referenciaService.AbstractRepository.ClearAll();
            _testeService.AbstractRepository.ClearAll();
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComConst()
        {
            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == _cdTipo);        
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComEnum()
        {
            var referenciaModel = 
                _referenciaService.AbstractRepository.FirstOrDefault();

            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == (int)referenciaModel.TipoEnum);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComEnumInt()
        {
            var tipoEnum = TipoEnum.Normal;

            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == (int)tipoEnum);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComEnumTipo()
        {
            _testeService.AbstractRepository
                 .FirstOrDefault(f => f.Cd_Tipo == (int)TipoEnum.Normal);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComVar()
        {
            var tipoEnumCod = 1;

            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == tipoEnumCod);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComVarConst()
        {
            const int tipoEnumConst = 1;

            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == tipoEnumConst);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComVarEnum()
        {
            var tipoEnumInt = (int)TipoEnum.Normal;

            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == tipoEnumInt);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComVarPriv()
        {
            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == (int)_tipoEnum);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComObjeto()
        {
            var referenciaModel =
                _referenciaService.AbstractRepository.FirstOrDefault();

            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == referenciaModel.Tipo.Cd_Tipo);
        }
    }
}