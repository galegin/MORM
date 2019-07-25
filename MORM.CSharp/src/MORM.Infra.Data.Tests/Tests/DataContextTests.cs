using Microsoft.VisualStudio.TestTools.UnitTesting;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Infra.CrossCutting;
using MORM.Infra.Data.Migrations;

namespace MORM.Infra.Data.Tests
{
    [TestClass]
    public class DataContextTests
    {
        private readonly IAbstractDataContext _dataContext;
        private readonly ITipoRepository _tipoRepository;
        private const int _cdTipo = 1;

        public DataContextTests()
        {
            _dataContext = AbstractContainer.Instance.Resolve<IAbstractDataContext>();
            _tipoRepository = AbstractContainer.Instance.Resolve<ITipoRepository>();
        }

        [TestInitialize]
        public void DataContextTests_Initialize()
        {
            DataContextTests_Cleanup();

            _tipoRepository.Salvar(new TipoModel { Cd_Tipo = _cdTipo });
        }

        [TestCleanup]
        public void DataContextTests_Cleanup()
        {
            _tipoRepository.ClearAll();
        }

        [TestMethod]
        public void DataContextTests_Migracao()
        {
            MigracaoContexto.Gerar(_dataContext);
        }

        [TestMethod]
        public void DataContextTests_Conexao()
        {
            var tipo = _tipoRepository.FirstOrDefault(f => f.Cd_Tipo == _cdTipo);
        }

        [TestMethod]
        public void DataContextTests_Dispose()
        {
            using (var context = AbstractContainer.Instance.Resolve<IAbstractDataContext>() as IAbstractDataContext)
            {
                var lista = context.GetListaW<TipoModel>(string.Empty);
            }
        }
    }
}