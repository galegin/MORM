using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;
using MORM.Apresentacao.Extensions;
using MORM.Apresentacao.Views;
using MORM.Dominio.Extensions;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractCampo : AbstractUserControl
    {
        #region propriedades
        private AbstractEditTipo EditTipo
        {
            get => EditIni.Tipo;
            set
            {
                EditIni.Tipo = value;
                EditFin.Tipo = value;
            }
        }
        #endregion

        #region construtores
        public AbstractCampo()
        {
            InitializeComponent();
            DataContext = new AbstractCampoViewModel();
        }

        public AbstractCampo(object source, string nomeBinding, AbstractCampoTipo tipo, MetadataCampo campo)
        {
            InitializeComponent();
            DataContext = new AbstractCampoViewModel(tipo, campo);
            EditTipo = campo.Prop.GetEditTipo();
            SetBindingCampo(campo.Prop, source, nomeBinding);
        }
        #endregion

        #region metodos

        #region click
        private void Label_Click(object sender, RoutedEventArgs e)
        {
            if (sender == null)
                return;

            if (sender == LabelBtn)
                sender = EditIni;

            var vm = DataContext as AbstractCampoViewModel;
            vm.SelecionarLista();
            vm.BuscarDescricao();
        }
        #endregion

        #region lostFocus
        private void Edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender == null)
                return;

            var vm = DataContext as AbstractCampoViewModel;
            vm.ConsultarChave();
            vm.BuscarDescricao();
            vm.GerarIntervalo();
        }
        #endregion

        #region previewKeyDown
        private void Edit_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
                Label_Click(sender, null);
        }
        #endregion

        #region binding
        private void SetBindingCampo(PropertyInfo prop, object source, string nomeBinding)
        {
            var vm = DataContext as AbstractCampoViewModel;

            SetBindingObjeto(EditIni, source, nomeBinding, new[] { $"{prop.Name}Ini", $"{prop.Name}" }, vm.CampoIni.IsExibir);
            SetBindingObjeto(EditFin, source, nomeBinding, new[] { $"{prop.Name}Fin", $"{prop.Name}" }, vm.CampoFin.IsExibir);
            SetBindingObjeto(EditDes, source, nomeBinding, new[] { $"{prop.Name}Des", $"{prop.Name}" }, vm.CampoDes.IsExibir);
            SetBindingObjeto(EditSel, source, nomeBinding, new[] { $"{prop.Name}Sel", $"{prop.Name}" }, vm.CampoSel.IsExibir);
            SetBindingObjeto(ComboTip, source, nomeBinding, new[] { $"{prop.Name}Tip", $"{prop.Name}" }, vm.CampoTip.IsExibir);
        }

        private void SetBindingObjeto(object control, object source, string nomeBinding, string[] campos, bool isExibir)
        {
            if (!isExibir)
                return;

            var objeto = source.GetInstancePropOrField(nomeBinding);
            var objetoType = source.GetInstancePropOrField("ElementType") as Type;

            foreach (var campo in campos)
            {
                var prop = objetoType.GetProperty(campo);
                if (prop != null)
                {
                    var binding = prop.GetDataBinding(source, nomeBinding);
                    if (control is TextBox)
                        (control as TextBox).SetBinding(TextBox.TextProperty, binding);
                    if (control is ComboBox)
                        (control as ComboBox).SetBinding(ComboBox.TextProperty, binding);
                    break;
                }
            }
        }
        #endregion

        #endregion
    }
}