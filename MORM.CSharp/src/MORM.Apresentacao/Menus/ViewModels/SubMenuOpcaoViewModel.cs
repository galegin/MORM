namespace MORM.Apresentacao
{
    public class SubMenuOpcaoViewModel : AbstractViewModel
    {
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

        #region construtores
        public SubMenuOpcaoViewModel(IMenuOpcao menuOpcao)
        {
            MenuOpcao = menuOpcao;
        }
        #endregion
        
        #region metodos
        public void Executar()
        {
            MenuOpcao.Executar();
        }
        #endregion
    }
}