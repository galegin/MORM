using MORM.CrossCutting;
using MORM.Repositorio.Mocks;

namespace MORM.Servico.Tests
{
    public class BaseTests : AbstractTests
    {
        static BaseTests()
        {
            var container = AbstractContainer.Instance;
            container.AddCrossCutting();
            container.AddServico();
            container.AddRepositorioMocks();
        }
    }
}