using MORM.Dominio.Interfaces;
using MORM.Infra.CrossCutting;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;

namespace MORM.Servico
{
    public class BaseInstaller
    {
        static BaseInstaller()
        {
            Install(AbstractContainer.Instance);
        }

        public static IAbstractContainer Container =>
            AbstractContainer.Instance;

        public static void Install(IAbstractContainer container)
        {
            container.Register<ITerminalAppService, TerminalAppService>();
            container.Register<IUsuarioAppService, UsuarioAppService>();
            container.Register<IAmbienteAppService, AmbienteAppService>();
            container.Register<ILogAcessoAppService, LogAcessoAppService>();
            container.Register<IMigracaoAppService, MigracaoAppService>();
            container.Register<IPermissaoAppService, PermissaoAppService>();
            container.Register<IEmpresaAppService, EmpresaAppService>();

            Infra.Data.BaseInstaller.Install(container);
        }
    }
}