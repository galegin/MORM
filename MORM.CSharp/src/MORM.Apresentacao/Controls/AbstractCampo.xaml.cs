using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.ViewsModel;
using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractCampo : AbstractUserControl
    {
        #region propriedades
        private AbstractCampoViewModel _vm => DataContext as AbstractCampoViewModel;
        private AbstractSource _source => _vm.Source;
        private AbstractCampoTipo _tipo => _vm.Tipo;
        private MetadataCampo _campo => _vm.Campo;
        private AbstractCampoFormato Formato
        {
            get => EditIni.Formato;
            set
            {
                EditIni.Formato = value;
                EditFin.Formato = value;
            }
        }
        #endregion

        #region construtores
        public AbstractCampo()
        {
            InitializeComponent();
            DataContext = new AbstractCampoViewModel();
        }

        public AbstractCampo(AbstractSource source, AbstractCampoTipo tipo, MetadataCampo campo)
        {
            InitializeComponent();
            DataContext = new AbstractCampoViewModel(source, tipo, campo);
            Formato = campo.Prop.GetCampoFormato();
            HabilitaCampo();
            SetarTamanho();
            SetBindingCampo();
        }
        #endregion

        #region metodos

        #region click
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == null)
                return;

            if (sender == LabelBtn)
                sender = EditIni;

            var vm = DataContext as AbstractCampoViewModel;
            vm.SelecionarLista();

            Edit_LostFocus(sender, e);
        }
        #endregion

        #region lostFocus
        private void Edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender == null)
                return;

            var vm = DataContext as AbstractCampoViewModel;
            if (vm.Campo.IsKey())
            {
                var vms = vm.Source.Source as IAbstractViewModel;
                vms?.ConsultarChave();
            }
            else
            {
                vm.BuscarDescricao();
            }
        }
        #endregion

        #region previewKeyDown
        private void Edit_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
                Button_Click(sender, null);
        }
        #endregion

        #region binding
        private void SetBindingCampo()
        {
            var cod = _campo.Prop.Name;

            if (_tipo.IsIndiv())
            {
                SetBindingObjeto(EditIni, cod);
                SetBindingObjeto(ComboTip, cod);
            }
        }

        private void SetBindingObjeto(UIElement control, params string[] campos)
        {
            if (control.Visibility != Visibility.Visible)
                return;

            var objeto = _source.GetInstancePropOrField(_source.Nome);
            var objetoType = _source.Source.GetInstancePropOrField("ElementType") as Type;

            foreach (var campo in campos)
            {
                var prop = objetoType.GetProperty(campo);
                if (prop != null)
                {
                    var binding = prop.GetDataBinding(_source);
                    if (control is TextBox)
                        (control as TextBox).SetBinding(TextBox.TextProperty, binding);
                    else if (control is ComboBox)
                        (control as ComboBox).SetBinding(ComboBox.TextProperty, binding);
                    break;
                }
            }
        }
        #endregion

        #region habilitaCampo
        private void HabilitaCampo()
        {
            var comps = new List<object>
            {
                LabelBtn,
            };

            if (_tipo.IsTipagem())
                comps.Add(ComboTip);
            else if (_tipo.IsSelecao())
                comps.Add(EditDes);
            else if (_tipo.IsInter())
            {
                comps.Add(EditIni);
                comps.Add(EditFin);
            }
            else if (_tipo.IsIndiv())
            {
                comps.Add(EditIni);
                if (_tipo.IsDescr())
                    comps.Add(EditDes);
            }

            comps
                .ForEach(comp =>
                {
                    (comp as UIElement).Visibility = Visibility.Visible;
                });
        }
        #endregion

        #region setarTamanho
        private void SetarTamanho()
        {
            LabelBtn.Width = 150;
            EditIni.Width = _tipo.IsInter() ? 150 : _campo.Tamanho * 10;
            EditFin.Width = _tipo.IsInter() ? 150 : _campo.Tamanho * 10;
            EditDes.Width = _tipo.IsInter() ? 300 : 150;
            ComboTip.Width = _tipo.IsInter() ? 300 : 150;
        }
        #endregion

        #endregion
    }
}