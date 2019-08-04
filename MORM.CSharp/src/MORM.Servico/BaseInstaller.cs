using MORM.Dominio.Interfaces;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;

namespace MORM.Servico
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<ITerminalAppService, TerminalAppService>();
            container.Register<IUsuarioAppService, UsuarioAppService>();
            container.Register<IAmbienteAppService, AmbienteAppService>();
            container.Register<ILogAcessoAppService, LogAcessoAppService>();
            container.Register<IMigracaoAppService, MigracaoAppService>();
            container.Register<IPermissaoAppService, PermissaoAppService>();
            container.Register<IEmpresaAppService, EmpresaAppService>();
            container.Register<IGrupoEmpresaAppService, GrupoEmpresaAppService>();
        }
    }
}