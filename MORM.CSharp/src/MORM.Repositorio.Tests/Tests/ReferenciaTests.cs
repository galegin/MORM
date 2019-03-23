using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Tests.Ioc.Container;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class ReferenciaTests
    {
        private readonly ITesteService _testeService;
        private readonly ReferenciaModel _referenciaModel;
        private readonly TipoEnum _tipoEnum;

        public ReferenciaTests()
        {
            _testeService = BaseContainer.Instance.Resolve<ITesteService>();
            _referenciaModel = new ReferenciaModel();
            _tipoEnum = TipoEnum.Normal;
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComConst()
        {
            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == 1);        
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComEnum()
        {
            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == (int)_referenciaModel.TipoEnum);
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
            _testeService.AbstractRepository
                .FirstOrDefault(f => f.Cd_Tipo == _referenciaModel.Tipo.Cd_Tipo);
        }
    }
}