using MORM.Apresentacao.Menus;
using MORM.Apresentacao.Views.Interfaces;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Mensagens;
using MORM.Apresentacao.WSist.Menus;
using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.Apresentacao.WSist
{
    public class BaseInstaller
    {
        public static void Install(IAbstractContainer container)
        {
            container.Register<IAmbiente, Ambiente>();
            container.Register<IUsuario, Usuario>();
            container.Register<IEmpresa, Empresa>();
            container.Register<ITerminal, Terminal>();
            container.Register<IInformacaoSistema, InformacaoSistema>();
            
            container.RegisterSingleton<IMainWindow, MainWindow>();
            container.RegisterSingleton<IMainLogin, MainLogin>();
            container.RegisterSingleton<IMainCommand, MainCommand>();
            container.RegisterSingleton<IMainMensagem, MainMensagem>();

            container.Register<IMenuResolver, MenuResolver>();

            container.Register<IMenuSistema, MenuSistema>();
            container.Register<IMenuLateral, ucMenuLateral>();
            container.Register<ITituloSistema, ucTituloSistema>();
            
            container.Register<IAmbienteView, AmbienteView>();
            container.Register<ILogAcessoView, LogAcessoView>();
            container.Register<IMigracaoEntView, MigracaoEntView>();
            container.Register<IPermissaoView, PermissaoView>();
            container.Register<IEmpresaView, EmpresaView>();
            container.Register<ITerminalView, TerminalView>();
            container.Register<IUsuarioView, UsuarioView>();
        }
    }
}