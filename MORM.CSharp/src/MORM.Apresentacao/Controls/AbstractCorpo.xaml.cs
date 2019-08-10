using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractCorpo : AbstractUserControl
    {
        public AbstractCorpo()
        {
            InitializeComponent();
        }

        public AbstractCorpo(List<AbstractViewItem> itens, 
            SelectionChangedEventHandler selectionChanged = null)
        {
            if (itens.Count == 0)
                return;

            if (itens.Count == 1)
            {
                Content = itens.FirstOrDefault().Controls.FirstOrDefault();
            }
            else
            {
                this.AddControl(new TabControl(), selectionChanged: selectionChanged);

                itens.ForEach(item =>
                {
                    this.AddControl(new TabItem { Header = item.Descricao }, controls: item.Controls);
                });
            }

            selectionChanged?.Invoke(Content, null);
        }
    }
}