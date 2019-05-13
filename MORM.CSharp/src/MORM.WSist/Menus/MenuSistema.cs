using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Menus;
using MORM.Utils.Excecoes;
using MORM.WSist.Views.Lista;
using MORM.WSist.Views.Manutencao;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MORM.WSist.Menus
{
    public class MenuSistema : IMenuSistema
    {
        private readonly IMenuResolverClasse _resolverClasse;
        private readonly IMenuResolverObjeto _resolverObjeto;
        private readonly IMenuResolverTipo _resolverTipo;

        public MenuSistema(
            IMenuResolverClasse resolverClasse, 
            IMenuResolverObjeto resolverObjeto, 
            IMenuResolverTipo resolverTipo)
        {
            _resolverClasse = resolverClasse ?? throw new ArgumentNullException(nameof(resolverClasse));
            _resolverObjeto = resolverObjeto ?? throw new ArgumentNullException(nameof(resolverObjeto));
            _resolverTipo = resolverTipo ?? throw new ArgumentNullException(nameof(resolverTipo));
        }

        public IList<IMenuOpcao> GetListaDeMenuOpcao()
        {
            var listaDeMenuOpcao = new List<IMenuOpcao>();

            listaDeMenuOpcao.Add(GetMenuManutencao());
            listaDeMenuOpcao.Add(GetMenuProcesso());
            listaDeMenuOpcao.Add(GetMenuConsulta());
            listaDeMenuOpcao.Add(GetMenuRelatorio());
            listaDeMenuOpcao.Add(GetMenuConfiguracao());
            listaDeMenuOpcao.Add(GetMenuFuncao());
            listaDeMenuOpcao.Add(GetMenuOutro());
            listaDeMenuOpcao.Add(GetMenuSair());

            return listaDeMenuOpcao;
        }

        private IMenuOpcao GetMenuManutencao()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IAbstractClienteViewManut>(MenuOpcaoTipo.Opcao, "MenuManutCliente", "Cliente", _resolverTipo),
                new MenuOpcaoTipo<IAbstractEmpresaViewManut>(MenuOpcaoTipo.Opcao, "MenuManutEmpresa", "Empresa", _resolverTipo),
                new MenuOpcaoTipo<IAbstractProdutoViewManut>(MenuOpcaoTipo.Opcao, "MenuManutProduto", "Produto", _resolverTipo),
                new MenuOpcaoTipo<IAbstractTerminalViewManut>(MenuOpcaoTipo.Opcao, "MenuManutTerminal", "Terminal", _resolverTipo),
                new MenuOpcaoTipo<IAbstractUsuarioViewManut>(MenuOpcaoTipo.Opcao, "MenuManutUsuario", "Usuario", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.Manutencao, "MenuManut", "Manutenção", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuProcesso()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuProcVenda", "Venda"),
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuProcCompra", "Compra"),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.Processo, "MenuProc", "Processo", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuConsulta()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuConsultaVenda", "Venda"),
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuConsultaCompra", "Compra"),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.Consulta, "MenuConsult", "Consulta", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuRelatorio()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuRelatVenda", "Venda"),
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuRelatCompra", "Compra"),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.Relatorio, "MenuRelat", "Relatório", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuConfiguracao()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuConfigEmpresa", "Empresa"),
                new MenuOpcaoDescr(MenuOpcaoTipo.Opcao, "MenuConfigUsuario", "Usuario"),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.Configuracao, "MenuConfig", "Configuração", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuFuncao()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoAcao(MenuOpcaoTipo.Opcao, "MenuFuncaoSplashing", "Splashing Box", 
                    () => LoadingBoxExtensions.SplashingBox("Inicializando...")),

                new MenuOpcaoAcao(MenuOpcaoTipo.Opcao, "MenuFuncaoLoading", "Loading Box",
                    () => LoadingBoxAcao()),

                new MenuOpcaoAcao(MenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "Progress Box",
                    () => ProgressBoxAcao()),

                new MenuOpcaoAcao(MenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "Message Log",
                    () => MensagemLogExtensions.ShowMensagemLog()),

                new MenuOpcaoAcao(MenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "Message Debug",
                    () => throw new ExceptionDebug("Exemplo de mensagem de debug")),

                new MenuOpcaoAcao(MenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "Message Info",
                    () => throw new ExceptionErro("Exemplo de mensagem de erro")),

                new MenuOpcaoAcao(MenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "Message Erro",
                    () => throw new ExceptionInfo("Exemplo de mensagem de info")),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuFuncao", "Função", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuOutro()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IAbstractPackIconViewLista>(MenuOpcaoTipo.Opcao, "MenuOutroPackIcon", "PackIcon", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.Configuracao, "MenuOutro", "Outro", subMenu);
            return menu;
        }

        private void LoadingBoxAcao()
        {
            LoadingBoxExtensions.OpenLoadingBox("Inicializando...");
            Thread.Sleep(1000);

            LoadingBoxExtensions.CloseLoadingBox();
        }

        private void ProgressBoxAcao()
        {
            LoadingBoxExtensions.OpenLoadingBox("Inicializando...");
            Thread.Sleep(1000);

            int qtde = 5;

            for (int i = 0; i < qtde; i++)
            {
                LoadingBoxExtensions.ProgressLoadingBox("Inicializando...", qtde, i + 1);
                Thread.Sleep(1000);
            }

            LoadingBoxExtensions.CloseLoadingBox();
        }

        private IMenuOpcao GetMenuSair()
        {
            var menu = new MenuOpcaoAcao(MenuOpcaoTipo.Opcao, "MenuSair", "Sair", () => { Environment.Exit(1); });
            return menu;
        }
    }
}