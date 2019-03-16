using MORM.Ioc.Installer;
using MORM.Repositorio.SqLite;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Tests.Ioc.Installer
{
    public class ConexaoInstaller : AbstractConexaoInstaller
    {
        protected override void Setup()
        {
            base.Setup();

            Register<IConnectionFactory, SqLiteHelper>();
        }
    }
}