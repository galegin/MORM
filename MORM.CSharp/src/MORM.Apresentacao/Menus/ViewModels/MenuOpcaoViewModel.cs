﻿using MaterialDesignThemes.Wpf;
using System.Linq;

namespace MORM.Apresentacao
{
    public class MenuOpcaoViewModel : AbstractViewModel
    {
        #region constantes
        private const int ALTURA = 40;
        #endregion

        #region variaveis
        private IMenuOpcao _menuOpcao;
        private bool _isExibirSubMenu;
        private bool _isContemSubMenu;
        private int _alturaMenuOpcao = ALTURA;
        private PackIconKind _packIconKindOpcao = PackIconKind.About;
        private PackIconKind _packIconKindMenu = PackIconKind.MenuDown;
        #endregion

        #region propriedades
        public IMenuOpcao MenuOpcao
        {
            get => _menuOpcao;
            set
            {
                SetField(ref _menuOpcao, value);
                IsContemSubMenu = _menuOpcao.SubMenuOpcao?.Any() ?? false;
            }
        }
        public bool IsExibirSubMenu
        {
            get => _isExibirSubMenu;
            set => SetField(ref _isExibirSubMenu, value);
        }
        public bool IsContemSubMenu
        {
            get => _isContemSubMenu;
            set => SetField(ref _isContemSubMenu, value);
        }
        public int AlturaMenuOpcao
        {
            get => _alturaMenuOpcao;
            set => SetField(ref _alturaMenuOpcao, value);
        }
        public PackIconKind PackIconKindOpcao
        {
            get => _packIconKindOpcao;
            set => SetField(ref _packIconKindOpcao, value);
        }
        public PackIconKind PackIconKindMenu
        {
            get => _packIconKindMenu;
            set => SetField(ref _packIconKindMenu, value);
        }
        #endregion

        #region comandos
        public ExecutarMenu ExecutarMenu { get; } = new ExecutarMenu();
        public ExibirSubMenu ExibirSubMenu { get; } = new ExibirSubMenu();
        #endregion

        #region construtores
        public MenuOpcaoViewModel(IMenuOpcao menuOpcao)
        {
            MenuOpcao = menuOpcao;
            PackIconKindOpcao = GetKindOpcao();
        }
        #endregion

        #region metodos
        public void SetarIsExibirSubMenu()
        {
            var qtdeSubMenu = MenuOpcao.SubMenuOpcao?.Count ?? 0;
            if (qtdeSubMenu == 0)
            {
                ExecutarMenu.Execute(this);
                return;
            }
            IsExibirSubMenu = !IsExibirSubMenu;
            AlturaMenuOpcao = (1 + (IsExibirSubMenu ? qtdeSubMenu : 0)) * ALTURA;
            PackIconKindMenu =
                IsExibirSubMenu ? PackIconKind.MenuDownOutline :
                PackIconKind.MenuDown;
        }

        private PackIconKind GetKindOpcao()
        {
            return (PackIconKind)(int)MenuOpcao.Tipo;
        }

        public void Executar()
        {
            MenuOpcao.Executar();
        }
        #endregion
    }
}