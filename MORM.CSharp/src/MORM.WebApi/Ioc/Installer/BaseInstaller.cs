using MORM.Aplicacao.Ioc.Installer;
using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Repositorio.Context;
using MORM.Repositorio.Interfaces;
using MORM.Repositorio.Uow;
using MORM.Servico.Interfaces;
using MORM.Servico.Services;

namespace MORM.WebApi.Ioc
{
    public class BaseInstaller : AbstractInstaller
    {
        public override void InstallerAmbiente()
        {
            Register<IAmbiente, Ambiente>();
            Register<IEmpresa, Empresa>();
            Register<ITerminal, Terminal>();
            Register<IUsuario, Usuario>();
        }

        public override void InstallerConexao()
        {
        }

        public override void InstallerDataConext()
        {
            Register<IAbstractDataContext, AbstractDataContext>();
        }

        public override void InstallerDomainServices()
        {
        }

        public override void InstallerRepositories()
        {
        }

        public override void InstallerServices()
        {
            //Register<IAmbienteApiService, AmbienteApiService>();
            Register<IAmbienteService, AmbienteService>();
            //Register<ILogAcessoApiService, LogAcessoApiService>();
            Register<ILogAcessoService, LogAcessoService>();
            //Register<IMigracaoEntApiService, MigracaoEntApiService>();
            Register<IMigracaoEntService, MigracaoEntService>();
            //Register<IPermissaoApiService, PermissaoApiService>();
            Register<IPermissaoService, PermissaoService>();
            Register<IEmpresaApiService, EmpresaApiService>();
            Register<IEmpresaService, EmpresaService>();
            Register<IGrupoEmpresaApiService, GrupoEmpresaApiService>();
            Register<IGrupoEmpresaService, GrupoEmpresaService>();
            Register<IBairroApiService, BairroApiService>();
            Register<IBairroService, BairroService>();
            Register<IEstadoApiService, EstadoApiService>();
            Register<IEstadoService, EstadoService>();
            Register<ILogradouroApiService, LogradouroApiService>();
            Register<ILogradouroService, LogradouroService>();
            Register<IMunicipioApiService, MunicipioApiService>();
            Register<IMunicipioService, MunicipioService>();
            Register<IPaisApiService, PaisApiService>();
            Register<IPaisService, PaisService>();
            Register<IOperacaoApiService, OperacaoApiService>();
            Register<IOperacaoService, OperacaoService>();
            Register<IPessoaApiService, PessoaApiService>();
            Register<IPessoaService, PessoaService>();
            Register<IProdutoApiService, ProdutoApiService>();
            Register<IProdutoService, ProdutoService>();
            Register<IProdutoBarraApiService, ProdutoBarraApiService>();
            Register<IProdutoBarraService, ProdutoBarraService>();
            Register<IProdutoKitApiService, ProdutoKitApiService>();
            Register<IProdutoKitService, ProdutoKitService>();
            Register<IProdutoSaldoApiService, ProdutoSaldoApiService>();
            Register<IProdutoSaldoService, ProdutoSaldoService>();
            Register<IProdutoValorApiService, ProdutoValorApiService>();
            Register<IProdutoValorService, ProdutoValorService>();
            Register<ITipoSaldoApiService, TipoSaldoApiService>();
            Register<ITipoSaldoService, TipoSaldoService>();
            Register<ITipoValorApiService, TipoValorApiService>();
            Register<ITipoValorService, TipoValorService>();
            Register<IRegraFiscalApiService, RegraFiscalApiService>();
            Register<IRegraFiscalService, RegraFiscalService>();
            Register<ITerminalApiService, TerminalApiService>();
            Register<ITerminalService, TerminalService>();
            Register<ITipoVariacaoApiService, TipoVariacaoApiService>();
            Register<ITipoVariacaoService, TipoVariacaoService>();
            Register<ITipoVariacaoMotivoApiService, TipoVariacaoMotivoApiService>();
            Register<ITipoVariacaoMotivoService, TipoVariacaoMotivoService>();
            Register<ITransacaoApiService, TransacaoApiService>();
            Register<ITransacaoService, TransacaoService>();
            Register<IUsuarioApiService, UsuarioApiService>();
            Register<IUsuarioService, UsuarioService>();
        }

        public override void InstallerUnitOfWork()
        {
            Register<IAbstractUnityOfWork, AbstractUnityOfWork>();
        }

        public override void InstallerViews()
        {
        }
    }
}