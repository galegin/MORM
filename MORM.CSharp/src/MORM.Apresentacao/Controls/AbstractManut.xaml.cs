using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Extensions;
using MORM.Apresentacao.ViewsModel;
using MORM.Infra.CrossCutting;
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

            var scrollViewer = new ScrollViewer();
            scrollViewer.Margin = new Thickness(10);
            scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            scrollViewer.CanContentScroll = true;
            Content = scrollViewer;

            var stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);
            scrollViewer.Content = stackPanel;

            vm.GetModel().GetType().GetProperties().ToList().ForEach(prop =>
            {
                if (prop.IsIgnoreCampo())
                    return;

                var campoTipo = AbstractCampoTipo.Individual;
                var descricao = prop.GetDescricao().GetTraducao();
                var tamanho = prop.GetTamanho();
                var precisao = prop.GetPrecisao();
                var editTipo = prop.GetEditTipo();
                var bindind = prop.GetDataBinding(vm, vm.GetNomeModel());
                var abstractCampo = new AbstractCampo(campoTipo, descricao, tamanho, precisao, editTipo);
                abstractCampo.Margin = new Thickness(0, 0, 0, 10);
                abstractCampo.SetDataBinding(bindind);
                stackPanel.Children.Add(abstractCampo);
            });
        }
    }
}