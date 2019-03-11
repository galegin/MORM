using MORM.Apresentacao.Comps;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractOpcao : AbstractUserControlNotify
    {
        #region construtor
        public AbstractOpcao()
        {
            InitializeComponent();
            SetDataContext();
        }
        #endregion

        #region variaveis
        private bool _isExibirFechar = true;
        private bool _isExibirLimpar = true;
        private bool _isExibirConsultar = true;
        private bool _isExibirSalvar = true;
        private bool _isExibirExcluir = true;
        #endregion

        #region propriedades
        public bool IsExibirFechar
        {
            get => _isExibirFechar;
            set => SetField(ref _isExibirFechar, value);
        }
        public bool IsExibirLimpar
        {
            get => _isExibirLimpar;
            set => SetField(ref _isExibirLimpar, value);
        }
        public bool IsExibirConsultar
        {
            get => _isExibirConsultar;
            set => SetField(ref _isExibirConsultar, value);
        }
        public bool IsExibirSalvar
        {
            get => _isExibirSalvar;
            set => SetField(ref _isExibirSalvar, value);
        }
        public bool IsExibirExcluir
        {
            get => _isExibirExcluir;
            set => SetField(ref _isExibirExcluir, value);
        }
        #endregion
    }
}