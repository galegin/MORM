using MaterialDesignThemes.Wpf;
using MORM.Apresentacao.Menus.Commands;
using MORM.Apresentacao.ViewsModel;
using System.Linq;

namespace MORM.Apresentacao.Menus.ViewModels
{
    public class MenuOpcaoViewModel : AbstractViewModel
    {
        #region construtores
        public MenuOpcaoViewModel(IMenuOpcao menuOpcao)
        {
            MenuOpcao = menuOpcao;
        }
        #endregion

        #region constantes
        private const int ALTURA = 40;
        #endregion

        #region variaveis
        private IMenuOpcao _menuOpcao;
        private bool _isExibirSubMenu;
        private bool _isContemSubMenu;
        private int _alturaMenuOpcao = ALTURA;
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
        public void Executar()
        {
            MenuOpcao.Executar();
        }
        #endregion
    }
}
