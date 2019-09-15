using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;
using System.Linq;

namespace MORM.Repositorio.Tests
{
    [TestClass]
    public class ReferenciaRepositoryTests : BaseTests
    {
        private readonly IReferenciaRepository _referenciaRepository;
        private readonly ITesteRepository _testeRepository;
        private readonly TipoEnum _tipoEnum = TipoEnum.Normal;
        private const int _cdTipo = 1;

        public ReferenciaRepositoryTests()
        {
            _referenciaRepository = Resolve<IReferenciaRepository>();
            _testeRepository = Resolve<ITesteRepository>();
        }

        [TestInitialize]
        public void ReferenciaTests_Initialize()
        {
        }

        [TestCleanup]
        public void ReferenciaTests_Cleanup()
        {
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComConst()
        {
            _testeRepository.GetAll()
                .FirstOrDefault(f => f.Cd_Tipo == _cdTipo);        
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComEnum()
        {
            var referenciaModel = 
                _referenciaRepository.GetAll().FirstOrDefault();

            _testeRepository.GetAll()
                .FirstOrDefault(f => f.Cd_Tipo == (int)referenciaModel.TipoEnum);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComEnumInt()
        {
            var tipoEnum = TipoEnum.Normal;

            _testeRepository.GetAll()
                .FirstOrDefault(f => f.Cd_Tipo == (int)tipoEnum);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComEnumTipo()
        {
            _testeRepository.GetAll()
                 .FirstOrDefault(f => f.Cd_Tipo == (int)TipoEnum.Normal);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComVar()
        {
            var tipoEnumCod = 1;

            _testeRepository.GetAll()
                .FirstOrDefault(f => f.Cd_Tipo == tipoEnumCod);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComVarConst()
        {
            const int tipoEnumConst = 1;

            _testeRepository.GetAll()
                .FirstOrDefault(f => f.Cd_Tipo == tipoEnumConst);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComVarEnum()
        {
            var tipoEnumInt = (int)TipoEnum.Normal;

            _testeRepository.GetAll()
                .FirstOrDefault(f => f.Cd_Tipo == tipoEnumInt);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComVarPriv()
        {
            _testeRepository.GetAll()
                .FirstOrDefault(f => f.Cd_Tipo == (int)_tipoEnum);
        }

        [TestMethod]
        public void ReferenciaTests_ConsultarComObjeto()
        {
            var referenciaModel =
                _referenciaRepository.GetAll().FirstOrDefault();

            _testeRepository.GetAll()
                .FirstOrDefault(f => f.Cd_Tipo == referenciaModel.Tipo.Cd_Tipo);
        }
    }
}