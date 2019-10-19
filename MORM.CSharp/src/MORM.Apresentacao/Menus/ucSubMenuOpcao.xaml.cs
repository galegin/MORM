namespace MORM.Apresentacao
{
    public partial class ucSubMenuOpcao : AbstractUserControl
    {
        #region construtores
        public ucSubMenuOpcao(IMenuOpcao menuOpcao)
        {
            InitializeComponent();
            DataContext = new SubMenuOpcaoViewModel(menuOpcao);
        }
        #endregion
    }
}