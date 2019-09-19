using MORM.CrossCutting;
using MORM.Dominio;
using MORM.Repositorio.Mocks;

namespace MORM.Servico.Tests
{
    public class BaseTests : AbstractTests
    {
        static BaseTests()
        {
            var container = AbstractContainer.Instance;
            container.AddDominio();
            container.AddCrossCutting();
            container.AddServico();
            container.AddRepositorioMocks();
        }
    }
}