using MORM.Apresentacao.Menus;
using MORM.Apresentacao.Views.Interfaces;
using MORM.Apresentacao.Views;
using MORM.Aplicacao.Ioc.Installer;
using MORM.Apresentacao;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Classes;
using MORM.Apresentacao.Mensagens;
using MORM.WSist.Menus;
using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;

namespace MORM.WSist.Ioc.Installer
{
    public class BaseInstaller : AbstractInstaller
    {
        public override void InstallerAmbiente()
        {
            Register<IAmbiente, Ambiente>();
            Register<IUsuario, Usuario>();
            Register<IEmpresa, Empresa>();
            Register<ITerminal, Terminal>();
            Register<IInformacaoSistema, InformacaoSistema>();
        }

        public override void InstallerViews()
        {
            RegisterSingleton<IMainWindow, MainWindow>();
            RegisterSingleton<IMainLogin, MainLogin>();
            RegisterSingleton<IMainCommand, MainCommand>();
            RegisterSingleton<IMainMensagem, MainMensagem>();

            Register<IMenuSistema, MenuSistema>();
            Register<IMenuLateral, ucMenuLateral>();
            Register<ITituloSistema, ucTituloSistema>();

            Register<IMenuResolverClasse, MenuResolverClasse>();
            Register<IMenuResolverObjeto, MenuResolverObjeto>();
            Register<IMenuResolverTipo, MenuResolverTipo>();

            Register<IAmbienteView, AmbienteView>();
            Register<ILogAcessoView, LogAcessoView>();
            Register<IMigracaoEntView, MigracaoEntView>();
            Register<IPermissaoView, PermissaoView>();
            Register<IEmpresaView, EmpresaView>();
            Register<IGrupoEmpresaView, GrupoEmpresaView>();
            Register<IBairroView, BairroView>();
            Register<IEstadoView, EstadoView>();
            Register<ILogradouroView, LogradouroView>();
            Register<IMunicipioView, MunicipioView>();
            Register<IPaisView, PaisView>();
            Register<IOperacaoView, OperacaoView>();
            Register<IPessoaView, PessoaView>();
            Register<IProdutoView, ProdutoView>();
            Register<IProdutoBarraView, ProdutoBarraView>();
            Register<IProdutoKitView, ProdutoKitView>();
            Register<IProdutoSaldoView, ProdutoSaldoView>();
            Register<IProdutoValorView, ProdutoValorView>();
            Register<ITipoSaldoView, TipoSaldoView>();
            Register<ITipoValorView, TipoValorView>();
            Register<IRegraFiscalView, RegraFiscalView>();
            Register<ITerminalView, TerminalView>();
            Register<ITipoVariacaoView, TipoVariacaoView>();
            Register<ITipoVariacaoMotivoView, TipoVariacaoMotivoView>();
            Register<ITransacaoView, TransacaoView>();
            Register<IUsuarioView, UsuarioView>();
        }
    }
}