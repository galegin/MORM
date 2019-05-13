using MORM.Apresentacao.Views;
using MORM.WSist.Controls;
using MORM.WSist.ViewsModel.Lista;
using System.Windows.Controls;

namespace MORM.WSist.Views.Lista
{
    public class AbstractPackIconViewLista : AbstractView, IAbstractPackIconViewLista
    {
        public AbstractPackIconViewLista() : base(null)
        {
            CreateLista(new AbstractPackIconViewModelLista());
        }

        private void CreateLista(AbstractPackIconViewModelLista vm)
        {
            DataContext = vm;

            var wrapPanel = new WrapPanel();
            AddChild(wrapPanel);

            foreach(var packIcon in vm.Lista)
            {
                var abstractPackIcon = new ucAbstractPackIcon(packIcon);
                wrapPanel.Children.Add(abstractPackIcon);
            }
        }
    }
}