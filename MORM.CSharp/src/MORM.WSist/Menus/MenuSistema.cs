using MORM.Apresentacao.Comps;
using MORM.WSist.Views.Manutencao;
using MORM.Utils.Excecoes;
using System;
using System.Collections.Generic;
using System.Threading;
using MORM.Apresentacao.Menus;

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
            listaDeMenuOpcao.Add(GetMenuSair());

            return listaDeMenuOpcao;
        }

        private IMenuOpcao GetMenuManutencao()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IAbstractClienteViewManut>(IMenuOpcaoTipo.Opcao, "MenuManutCliente", "\tCliente", _resolverTipo),
                new MenuOpcaoTipo<IAbstractProdutoViewManut>(IMenuOpcaoTipo.Opcao, "MenuManutProduto", "\tProduto", _resolverTipo),
            };

            var menu = new MenuOpcaoDescr(IMenuOpcaoTipo.SubMenu, "MenuManut", "Manutenção", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuProcesso()
        {
            var menu = new MenuOpcaoDescr(IMenuOpcaoTipo.SubMenu, "MenuProc", "Processo");
            return menu;
        }

        private IMenuOpcao GetMenuConsulta()
        {
            var menu = new MenuOpcaoDescr(IMenuOpcaoTipo.SubMenu, "MenuConsult", "Consulta");
            return menu;
        }

        private IMenuOpcao GetMenuRelatorio()
        {
            var menu = new MenuOpcaoDescr(IMenuOpcaoTipo.SubMenu, "MenuRelat", "Relatório");
            return menu;
        }

        private IMenuOpcao GetMenuConfiguracao()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoDescr(IMenuOpcaoTipo.Opcao, "MenuConfigEmpresa", "\tEmpresa"),
                new MenuOpcaoDescr(IMenuOpcaoTipo.Opcao, "MenuConfigUsuario", "\tUsuario"),
            };

            var menu = new MenuOpcaoDescr(IMenuOpcaoTipo.SubMenu, "MenuConfig", "Configuração", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuFuncao()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoAcao(IMenuOpcaoTipo.Opcao, "MenuFuncaoSplashing", "\tSplashing Box", 
                    () => LoadingBoxExtensions.SplashingBox("Inicializando...")),

                new MenuOpcaoAcao(IMenuOpcaoTipo.Opcao, "MenuFuncaoLoading", "\tLoading Box",
                    () => LoadingBoxAcao()),

                new MenuOpcaoAcao(IMenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "\tProgress Box",
                    () => ProgressBoxAcao()),

                new MenuOpcaoAcao(IMenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "\tMessage Log",
                    () => MensagemLogExtensions.ShowMensagemLog()),

                new MenuOpcaoAcao(IMenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "\tMessage Debug",
                    () => throw new ExceptionDebug("Exemplo de mensagem de debug")),

                new MenuOpcaoAcao(IMenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "\tMessage Info",
                    () => throw new ExceptionErro("Exemplo de mensagem de erro")),

                new MenuOpcaoAcao(IMenuOpcaoTipo.Opcao, "MenuFuncaoProgress", "\tMessage Erro",
                    () => throw new ExceptionInfo("Exemplo de mensagem de info")),
            };

            var menu = new MenuOpcaoDescr(IMenuOpcaoTipo.SubMenu, "MenuFuncao", "Função", subMenu);
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
            var menu = new MenuOpcaoAcao(IMenuOpcaoTipo.Opcao, "MenuSair", "Sair", () => { Environment.Exit(1); });
            return menu;
        }
    }
}