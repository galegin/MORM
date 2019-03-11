using MORM.IoC.Installer;
using MORM.Repositorio.SqLite;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Tests.IoC.Installer
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