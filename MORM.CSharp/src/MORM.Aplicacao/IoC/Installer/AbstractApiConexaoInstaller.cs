//using MORM.Repositorio.Interfaces;
//using MORM.Utilidade.Interfaces;

using MORM.Ioc.Installer;

namespace MORM.Aplicacao.Ioc.Installer
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