using MORM.Apresentacao.Menus.Commands;
using MORM.Apresentacao.ViewModels;

namespace MORM.Apresentacao.Menus.ViewModels
{
    public class SubMenuOpcaoViewModel : AbstractViewModel
    {
        #region construtores
        public SubMenuOpcaoViewModel(IMenuOpcao menuOpcao)
        {
            MenuOpcao = menuOpcao;
        }
        #endregion
        
        #region variaveis
        private IMenuOpcao _menuOpcao;
        #endregion

        #region propriedades
        public IMenuOpcao MenuOpcao
        {
            get => _menuOpcao;
            set => SetField(ref _menuOpcao, value);
        } 
        #endregion

        #region comandos
        public ExecutarSubMenu ExecutarSubMenu { get; } = new ExecutarSubMenu();
        #endregion

        #region metodos
        public void Executar()
        {
            MenuOpcao.Executar();
        }
        #endregion
    }
}