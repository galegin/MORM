using MaterialDesignThemes.Wpf;

namespace MORM.Apresentacao.WSist
{
    public partial class ucAbstractPackIcon : AbstractView
    {
        public ucAbstractPackIcon(PackIconKind packIconKind) : base(null)
        {
            InitializeComponent();
            DataContext = new AbstractPackIconViewModel(packIconKind);
        }
    }
}
