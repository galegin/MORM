using MORM.CrossCutting;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao
{
    public partial class AbstractBusca : AbstractUserControl
    {
        public AbstractBusca()
        {
            InitializeComponent();
        }

        public AbstractBusca(IAbstractViewModel vm) : this()
        {
            DataContext = vm;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                var vm = DataContext as IAbstractViewModel;
                vm.Expressao = (sender as TextBox)?.Text?.AllTrim();
                vm.ConsultarLista();
            }
        }
    }
}