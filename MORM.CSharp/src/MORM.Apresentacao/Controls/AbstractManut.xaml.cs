using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.ViewsModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractManut : AbstractUserControl
    {
        public AbstractManut()
        {
            InitializeComponent();
        }

        public AbstractManut(IAbstractViewModel vm) : this()
        {
            CreateComps(vm);
        }

        private void CreateComps(IAbstractViewModel vm)
        {
            DataContext = vm;

            this.AddPainel(new ScrollViewer()
            {
                Margin = new Thickness(10),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                CanContentScroll = true,
            });

            vm.ElementType
                .GetMetadata()
                .Campos
                .Where(p => !p.Prop.IsIgnoreCampo())
                .ToList()
                .ForEach(campo =>
                {
                    this.AddCampo(vm, nameof(vm.Model), campo, AbstractCampoTipo.Individual);
                });
        }
    }
}