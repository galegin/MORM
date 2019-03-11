//using MORM.Repositorio.Interfaces;
//using MORM.Utilidade.Interfaces;

using MORM.IoC.Installer;

namespace MORM.Aplicacao.IoC.Installer
{
    public class AbstractApiConexaoInstaller : AbstractConexaoInstaller
    {
        protected override void Setup()
        {
            //Register<IConnectionFactory, ConnectionFactory>();
            //Register<IConexao, Conexao>();
        }
    }
}