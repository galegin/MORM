using MORM.CrossCutting;
using MORM.Dominio;

namespace MORM.Database.Tests
{
    public class BaseTests : AbstractTests
    {
        static BaseTests()
        {
            var container = AbstractContainer.Instance;
            container.AddDominio();
        }
    }
}