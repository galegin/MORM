using MORM.CrossCutting;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MORM.Apresentacao
{
    public partial class AbstractCampo : AbstractUserControl
    {
        #region variaveis
        private const double _alturaCampo = 30;
        private const double _larguraCampo = 10;
        #endregion

        #region propriedades
        private AbstractCampoViewModel _vm => DataContext as AbstractCampoViewModel;
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
            SetarCampoMemo();
            SetarCampoComp();
            SetarCampoGrade();
            SetarFonte();
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

            _vm.SelecionarLista();

            Edit_LostFocus(sender, e);
        }
        #endregion

        #region lostFocus
        private void Edit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender == null)
                return;

            if (_vm.Tipo.IsIndiv() && _vm.Campo.IsKey())
            {
                var vms = _vm.Source.Source as IAbstractViewModel;
                vms?.ConsultarChave();
            }
        }
        #endregion

        #region textChanged
        private void Edit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender == null)
                return;

            if (_vm.Tipo.IsIndiv() && _vm.Campo.IsClasse())
            {
                _vm.BuscarDescricao();
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

        #region setarBinding
        private void SetBindingCampo()
        {
            if (_vm.Tipo.IsIndiv())
            {
                SetBindingObjeto(EditIni, _vm.Campo.Prop.Name);
                SetBindingObjeto(ComboTip, _vm.Campo.Prop.Name);
            }
        }

        private void SetBindingObjeto(UIElement control, params string[] campos)
        {
            if (control.Visibility != Visibility.Visible)
                return;

            var objeto = _vm.Source.GetInstancePropOrField(_vm.Source.Nome);
            var objetoType = _vm.Source.Source.GetInstancePropOrField("ElementType") as Type;

            foreach (var campo in campos)
            {
                var prop = objetoType.GetProperty(campo);
                if (prop != null)
                {
                    var binding = prop.GetDataBinding(_vm.Source);
                    control.SetBindingObjeto(binding);
                    break;
                }
            }
        }

        private void SetBindingFiltro(UIElement control, params string[] paths)
        {
            var binding = _vm.Campo.Prop.GetDataBinding(_vm.Source, paths: paths);
            control.SetBindingObjeto(binding);
        }
        #endregion

        #region habilitaCampo
        private void HabilitaCampo()
        {
            var comps = new List<object>
            {
                LabelBtn,
            };

            if (_vm.Tipo.IsTipagem())
                comps.Add(ComboTip);
            else if (_vm.Tipo.IsSelecao())
                comps.Add(EditDes);
            else if (_vm.Tipo.IsInter())
            {
                comps.Add(EditIni);
                comps.Add(EditFin);
            }
            else if (_vm.Tipo.IsIndiv())
            {
                comps.Add(EditIni);
                if (_vm.Tipo.IsDescr())
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
            EditIni.Width = _vm.Tipo.IsInter() ? 150 : _vm.Campo.Tamanho * _larguraCampo;
            EditFin.Width = _vm.Tipo.IsInter() ? 150 : _vm.Campo.Tamanho * _larguraCampo;
            EditDes.Width = _vm.Tipo.IsInter() ? 300 : 150;
            ComboTip.Width = _vm.Tipo.IsInter() ? 300 : 150;
        }
        #endregion

        #region setarCampoMemo
        private void SetarCampoMemo()
        {
            if (_vm.Tipo.IsInter())
                return;

            var campoMemo = _vm.Campo.Prop.GetCampoMemo();
            if (campoMemo == null)
                return;

            EditIni.AcceptsReturn = true;
            EditIni.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            EditIni.Tag = NavegacaoComEnter.IgnorarNavegacao;
            EditIni.TextWrapping = TextWrapping.Wrap;
            EditIni.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            if (campoMemo.Altura > 0)
                EditIni.Height = campoMemo.Altura * _alturaCampo;
            if (campoMemo.Largura > 0)
                EditIni.Width = campoMemo.Largura * _larguraCampo;
        }
        #endregion

        #region setarCampoMemo
        private void SetarCampoComp()
        {
            if (_vm.Tipo.IsInter())
                return;

            var campoComp = _vm.Campo.Prop.GetCampoComp();
            if (campoComp == null)
                return;

            EditIni.IsReadOnly = true;
            EditIni.MouseDoubleClick += CampoComp_MouseDoubleClick;
        }
        private void CampoComp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var campoComp = _vm.Campo.Prop.GetCampoComp();
            if (campoComp == null)
                return;

            var userControl = AbstractContainer.Instance.Resolve(campoComp.ElementType) as AbstractUserControl;
            if (userControl == null)
                return;

            userControl.Values = _vm.Model.GetInstancePropOrField(_vm.Campo.Prop.Name);

            if ((TelaUtils.Instance.AbrirDialog(userControl) ?? false) && userControl.InConfirmado)
            {
                _vm.Model.SetInstancePropOrField(_vm.Campo.Prop.Name, userControl.Values);
            }
        }
        #endregion

        #region setarCampoGrade
        private void SetarCampoGrade()
        {
            if (_vm.Tipo.IsInter())
                return;

            var campoGrade = _vm.Campo.Prop.GetCampoGrade();
            if (campoGrade == null)
                return;

            EditIni.IsReadOnly = true;
            EditIni.MouseDoubleClick += CampoGrade_MouseDoubleClick;
        }
        private void CampoGrade_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var campoGrade = _vm.Campo.Prop.GetCampoGrade();
            if (campoGrade == null)
                return;

            var userControl = AbstractContainer.Instance.Resolve(campoGrade.ElementType) as AbstractUserControl;
            if (userControl == null)
                return;

            userControl.Values = _vm.Model.GetInstancePropOrField(_vm.Campo.Prop.Name);

            if ((TelaUtils.Instance.AbrirDialog(userControl) ?? false) && userControl.InConfirmado)
            {
                _vm.Model.SetInstancePropOrField(_vm.Campo.Prop.Name, userControl.Values);
            }
        }
        #endregion

        #region setarFonte
        private void SetarFonte()
        {
            if (_vm.Campo.IsKey() || _vm.Campo.IsReq())
                LabelBtn.FontWeight = FontWeights.Bold;
            if (_vm.Campo.IsClasse())
            {
                LabelBtn.FontStyle = FontStyles.Italic;
                LabelBtn.Foreground = Brushes.Blue;
            }
        }
        #endregion

        #endregion
    }
}