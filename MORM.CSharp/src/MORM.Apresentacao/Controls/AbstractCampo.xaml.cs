using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;
using System.Windows.Controls;
using System.Windows.Data;

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
        public AbstractCampo(AbstractCampoTipo tipo, 
            string descricao = null, int tamanho = 0, int precisao = 0, 
            AbstractEditTipo? editTipo = null)
        {
            InitializeComponent();
            DataContext = new AbstractCampoViewModel(tipo, descricao, tamanho, precisao, editTipo);
            EditTipo = editTipo.Value;
        }
        #endregion

        #region metodos
        public void SetDataBinding(Binding bindingIni = null, Binding bindingFin = null, 
            Binding bindingDes = null, Binding bindingTip = null)
        {
            var vm = DataContext as AbstractCampoViewModel;

            if (bindingIni != null)
                EditIni.SetBinding(TextBox.TextProperty, bindingIni);
            if (bindingFin != null)
                EditFin.SetBinding(TextBox.TextProperty, bindingFin);
            if (bindingDes != null)
                EditDes.SetBinding(TextBox.TextProperty, bindingDes);
            if (bindingTip != null)
                ComboTip.SetBinding(ComboBox.TextProperty, bindingTip);
        }
        #endregion
    }
}