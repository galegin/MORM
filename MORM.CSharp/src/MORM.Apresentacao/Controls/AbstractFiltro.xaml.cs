using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Extensions;
using MORM.Apresentacao.ViewsModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractFiltro : AbstractUserControl
    {
        public AbstractFiltro()
        {
            InitializeComponent();
        }

        public AbstractFiltro(IAbstractViewModel vm) : this()
        {
            CreateComps(vm);
        }

        private void CreateComps(IAbstractViewModel vm)
        {
            DataContext = vm;

            AddPainel(new ScrollViewer()
            {
                Margin = new Thickness(10),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                CanContentScroll = true,
            });

            vm.ElementType
                .GetProperties()
                .Where(p => !p.IsIgnoreCampo())
                .ToList()
                .ForEach(prop =>
                {
                    AddCampo(vm, nameof(vm.Filtro), prop, AbstractCampoTipo.Intervalo);
                });
        }
    }
}