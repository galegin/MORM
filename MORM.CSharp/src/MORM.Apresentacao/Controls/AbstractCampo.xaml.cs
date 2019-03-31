using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractCampo : AbstractUserControlNotify
    {
        #region variaveis
        private AbstractEditTipo _editTipo;
        #endregion

        #region propriedades
        private AbstractEditTipo EditTipo
        {
            get => _editTipo;
            set
            {
                SetField(ref _editTipo, value);
                EditIni.Tipo = value;
                EditFin.Tipo = value;
            }
        }
        #endregion

        #region construtores
        public AbstractCampo(AbstractCampoTipo tipo, string descricao = null, AbstractEditTipo? editTipo = null)
        {
            InitializeComponent();
            DataContext = new AbstractCampoViewModel(tipo, descricao, editTipo);
            EditTipo = editTipo.Value;
        }
        #endregion

        #region metodos
        public void SetDataBinding(Binding bindingIni = null, Binding bindingFin = null, Binding bindingDes = null)
        {
            if (bindingIni != null)
                EditIni.SetBinding(TextBox.TextProperty, bindingIni);
            if (bindingFin != null)
                EditFin.SetBinding(TextBox.TextProperty, bindingFin);
            if (bindingDes != null)
                EditDes.SetBinding(TextBox.TextProperty, bindingDes);
        }
        #endregion
    }
}