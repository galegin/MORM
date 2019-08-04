using MORM.Apresentacao.Menus;
using MORM.Apresentacao.Views.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.WSist.Menus
{
    public class MenuSistema : AbstractMenuSistema
    {
        public MenuSistema(IMenuResolver resolver) : base(resolver)
        {
        }

        public override IList<IMenuOpcao> GetListaDeMenuOpcao()
        {
            var listaDeMenuOpcao = new List<IMenuOpcao>();

            listaDeMenuOpcao.Add(GetMenuAmbiente());
            listaDeMenuOpcao.Add(GetMenuEmpresa());
            listaDeMenuOpcao.Add(GetMenuTerminal());
            listaDeMenuOpcao.Add(GetMenuUsuario());
            listaDeMenuOpcao.Add(GetMenuConfiguracao());
            listaDeMenuOpcao.Add(GetMenuSair());

            return listaDeMenuOpcao;
        }

        private IMenuOpcao GetMenuAmbiente()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IAmbienteView>(MenuOpcaoTipo.Opcao, "MenuAmbienteAmbiente", "Ambiente", _resolver),
                new MenuOpcaoTipo<ILogAcessoView>(MenuOpcaoTipo.Opcao, "MenuAmbienteLogAcesso", "LogAcesso", _resolver),
                new MenuOpcaoTipo<IMigracaoEntView>(MenuOpcaoTipo.Opcao, "MenuAmbienteMigracaoEnt", "MigracaoEnt", _resolver),
                new MenuOpcaoTipo<IPermissaoView>(MenuOpcaoTipo.Opcao, "MenuAmbientePermissao", "Permissao", _resolver),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuAmbiente", "Ambiente", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuEmpresa()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IEmpresaView>(MenuOpcaoTipo.Opcao, "MenuEmpresaEmpresa", "Empresa", _resolver),
                new MenuOpcaoTipo<IGrupoEmpresaView>(MenuOpcaoTipo.Opcao, "MenuGrupoEmpresaEmpresa", "GrupoEmpresa", _resolver),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuEmpresa", "Empresa", subMenu);
            return menu;
        }


        private IMenuOpcao GetMenuTerminal()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<ITerminalView>(MenuOpcaoTipo.Opcao, "MenuTerminalTerminal", "Terminal", _resolver),
            };

            var menu = new MenuOpcaoDescr(MenuOpcaoTipo.SubMenu, "MenuTerminal", "Terminal", subMenu);
            return menu;
        }

        private IMenuOpcao GetMenuUsuario()
        {
            var subMenu = new List<IMenuOpcao>
            {
                new MenuOpcaoTipo<IUsuarioView>(MenuOpcaoTipo.Opcao, "MenuUsuarioUsuario", "Usuario", _resolver),
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