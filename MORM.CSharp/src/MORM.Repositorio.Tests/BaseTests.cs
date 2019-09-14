using MORM.CrossCutting;
using MORM.Dominio;
using MORM.Repositorio.Dapper;
using MORM.Servico;

namespace MORM.Repositorio.Tests
{
    public class BaseTests : AbstractTests
    {
        static BaseTests()
        {
            var container = AbstractContainer.Instance;
            container.AddDominio();
            container.AddCrossCutting();
            container.AddServico();
            container.AddRepositorio();
            container.AddRepositorioDapper();
            container.AddRepositorioTests();
        }
    }
}