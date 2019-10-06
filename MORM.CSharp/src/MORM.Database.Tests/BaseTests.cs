using MORM.CrossCutting;

namespace MORM.Database.Tests
{
    public class BaseTests : AbstractTests
    {
        static BaseTests()
        {
            var container = AbstractContainer.Instance;
            container.AddCrossCutting();
        }
    }
}