using MORM.Apresentacao.Menus;
using MORM.Apresentacao.Views.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.WSist.Menus
{
    public class MenuSistema : AbstractMenuSistema
    {
        public MenuSistema(IMenuResolverClasse rc, IMenuResolverObjeto ro, IMenuResolverTipo rt) : base(rc, ro, rt)
        {
        }

        public override IList<IMenuOpcao> GetListaDeMenuOpcao()
        {
            var listaDeMenuOpcao = new List<IMenuOpcao>();

            listaDeMenuOpcao.Add(GetMenuAmbiente());
            listaDeMenuOpcao.Add(GetMenuComum());
            listaDeMenuOpcao.Add(GetMenuEmpresa());
            listaDeMenuOpcao.Add(GetMenuMunicipio());
            listaDeMenuOpcao.Add(GetMenuOperacao());
            listaDeMenuOpcao.Add(GetMenuPessoa());
            listaDeMenuOpcao.Add(GetMenuProduto());
            listaDeMenuOpcao.Add(GetMenuRegraFiscal());
            listaDeMenuOpcao.Add(GetMenuTerminal());
            listaDeMenuOpcao.Add(GetMenuTransacao());
            listaDeMenuOpcao.Add(GetMenuUsuario());
            listaDeMenuOpcao.Add(GetMenuConfiguracao());
            listaDeMenuOpcao.Add(GetMenuSair());

            return listaDeMenuOpcao;
        }

        private IMenuOpcao GetMenuAmbiente()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IAmbienteView>(MenuOpcaoTipo.Opcao, "MenuAmbienteAmbiente", "Ambiente", _resolverTipo),
                new MenuOpcaoTipo<ILogAcessoView>(MenuOpcaoTipo.Opcao, "MenuAmbienteLogAcesso", "LogAcesso", _resolverTipo),
                new MenuOpcaoTipo<IMigracaoEntView>(MenuOpcaoTipo.Opcao, "MenuAmbienteMigracaoEnt", "MigracaoEnt", _resolverTipo),
                new MenuOpcaoTipo<IPermissaoView>(MenuOpcaoTipo.Opcao, "MenuAmbientePermissao", "Permissao", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuAmbiente", "Ambiente", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuComum()
        {
            var subMenu = new List<IMenuOpcao>
            {

            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuComum", "Comum", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuEmpresa()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IEmpresaView>(MenuOpcaoTipo.Opcao, "MenuEmpresaEmpresa", "Empresa", _resolverTipo),
                new MenuOpcaoTipo<IGrupoEmpresaView>(MenuOpcaoTipo.Opcao, "MenuEmpresaGrupoEmpresa", "GrupoEmpresa", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuEmpresa", "Empresa", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuMunicipio()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IBairroView>(MenuOpcaoTipo.Opcao, "MenuMunicipioBairro", "Bairro", _resolverTipo),
                new MenuOpcaoTipo<IEstadoView>(MenuOpcaoTipo.Opcao, "MenuMunicipioEstado", "Estado", _resolverTipo),
                new MenuOpcaoTipo<ILogradouroView>(MenuOpcaoTipo.Opcao, "MenuMunicipioLogradouro", "Logradouro", _resolverTipo),
                new MenuOpcaoTipo<IMunicipioView>(MenuOpcaoTipo.Opcao, "MenuMunicipioMunicipio", "Municipio", _resolverTipo),
                new MenuOpcaoTipo<IPaisView>(MenuOpcaoTipo.Opcao, "MenuMunicipioPais", "Pais", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuMunicipio", "Municipio", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuOperacao()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IOperacaoView>(MenuOpcaoTipo.Opcao, "MenuOperacaoOperacao", "Operacao", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuOperacao", "Operacao", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuPessoa()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IPessoaView>(MenuOpcaoTipo.Opcao, "MenuPessoaPessoa", "Pessoa", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuPessoa", "Pessoa", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuProduto()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IProdutoView>(MenuOpcaoTipo.Opcao, "MenuProdutoProduto", "Produto", _resolverTipo),
                new MenuOpcaoTipo<IProdutoBarraView>(MenuOpcaoTipo.Opcao, "MenuProdutoProdutoBarra", "ProdutoBarra", _resolverTipo),
                new MenuOpcaoTipo<IProdutoKitView>(MenuOpcaoTipo.Opcao, "MenuProdutoProdutoKit", "ProdutoKit", _resolverTipo),
                new MenuOpcaoTipo<IProdutoSaldoView>(MenuOpcaoTipo.Opcao, "MenuProdutoProdutoSaldo", "ProdutoSaldo", _resolverTipo),
                new MenuOpcaoTipo<IProdutoValorView>(MenuOpcaoTipo.Opcao, "MenuProdutoProdutoValor", "ProdutoValor", _resolverTipo),
                new MenuOpcaoTipo<ITipoSaldoView>(MenuOpcaoTipo.Opcao, "MenuProdutoTipoSaldo", "TipoSaldo", _resolverTipo),
                new MenuOpcaoTipo<ITipoValorView>(MenuOpcaoTipo.Opcao, "MenuProdutoTipoValor", "TipoValor", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuProduto", "Produto", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuRegraFiscal()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IRegraFiscalView>(MenuOpcaoTipo.Opcao, "MenuRegraFiscalRegraFiscal", "RegraFiscal", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuRegraFiscal", "RegraFiscal", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuTerminal()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<ITerminalView>(MenuOpcaoTipo.Opcao, "MenuTerminalTerminal", "Terminal", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuTerminal", "Terminal", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuTransacao()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<ITipoVariacaoView>(MenuOpcaoTipo.Opcao, "MenuTransacaoTipoVariacao", "TipoVariacao", _resolverTipo),
                new MenuOpcaoTipo<ITipoVariacaoMotivoView>(MenuOpcaoTipo.Opcao, "MenuTransacaoTipoVariacaoMotivo", "TipoVariacaoMotivo", _resolverTipo),
                new MenuOpcaoTipo<ITransacaoView>(MenuOpcaoTipo.Opcao, "MenuTransacaoTransacao", "Transacao", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuTransacao", "Transacao", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuUsuario()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IUsuarioView>(MenuOpcaoTipo.Opcao, "MenuUsuarioUsuario", "Usuario", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuUsuario", "Usuario", subMenu);
            return menu;
        }


        private IMenuOpcao GetMenuConfiguracao()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuConfigEmpresa", "Empresa"),
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuConfigUsuario", "Usuario"),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuConfig", "Configuração", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuSair()
        {
            var menu = new MenuOpcaoAcao(MenuOpcaoTipo.Opcao, "MenuSair", "Sair", () => { Environment.Exit(1); });
            return menu;
        }
    }
}