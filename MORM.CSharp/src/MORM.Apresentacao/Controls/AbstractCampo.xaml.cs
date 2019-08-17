using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.ViewsModel;
using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractCampo : AbstractUserControl
    {
        #region propriedades
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
            HabilitaCampo(tipo);
            SetarTamanho(campo);
            SetBindingCampo(campo, source);
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
        private void SetBindingCampo(MetadataCampo campo, AbstractSource source)
        {
            var vm = DataContext as AbstractCampoViewModel;
            var cod = campo.Prop.Name;

            SetBindingObjeto(EditIni, source, $"{cod}Ini", $"{cod}");
            SetBindingObjeto(EditFin, source, $"{cod}Fin");
            SetBindingObjeto(EditDes, source, $"{cod}Des");
            SetBindingObjeto(ComboTip, source, $"{cod}Tip");
        }

        private void SetBindingObjeto(UIElement control, AbstractSource source, params string[] campos)
        {
            if (control.Visibility != Visibility.Visible)
                return;

            var objeto = source.GetInstancePropOrField(source.Nome);
            var objetoType = source.Source.GetInstancePropOrField("ElementType") as Type;

            foreach (var campo in campos)
            {
                var prop = objetoType.GetProperty(campo);
                if (prop != null)
                {
                    var binding = prop.GetDataBinding(source);
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
        private void HabilitaCampo(AbstractCampoTipo tipo)
        {
            var comps = new List<object>
            {
                tipo.IsIndiv() || tipo.IsInter() ? LabelBtn : null,
                tipo.IsIndiv() || tipo.IsInter() ? EditIni : null,
                tipo.IsInter() ? EditFin : null,
                tipo.IsDescr() || tipo.IsSelecao() ? EditDes : null,
                tipo.IsTipagem() ? ComboTip : null,
            };

            comps
                .Where(c => c != null)
                .ToList()
                .ForEach(comp =>
                {
                    (comp as UIElement).Visibility = Visibility.Visible;
                });
        }
        #endregion

        #region setarTamanho
        private void SetarTamanho(MetadataCampo campo)
        {
            LabelBtn.Width = 150;
            EditIni.Width = campo.Tamanho * 10;
            EditFin.Width = campo.Tamanho * 10;
            EditDes.Width = 300;
            EditDes.Width = 150;
        }
        #endregion

        #endregion
    }
}