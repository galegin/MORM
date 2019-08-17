using MORM.Apresentacao.Menus;
using MORM.Apresentacao.Views.Interfaces;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.WSist.Menus;
using MORM.Infra.CrossCutting;

namespace MORM.Apresentacao.WSist
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IMenuSistema, MenuSistema>();
            
            container.Register<IAmbienteView, AmbienteView>();
            container.Register<ILogAcessoView, LogAcessoView>();
            container.Register<IMigracaoEntView, MigracaoEntView>();
            container.Register<IPermissaoView, PermissaoView>();
            container.Register<IEmpresaView, EmpresaView>();
            container.Register<IGrupoEmpresaView, GrupoEmpresaView>();
            container.Register<ITerminalView, TerminalView>();
            container.Register<IUsuarioView, UsuarioView>();
        }
    }
}