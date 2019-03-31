using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractCampoViewModel : AbstractViewModel
    {
        #region constantes
        #endregion

        #region variaveis
        private AbstractCampoTipo _tipo;
        private AbstractEditTipo _editTipo;
        private bool _isExibirBtn;
        private bool _isExibirIni;
        private bool _isExibirFin;
        private bool _isExibirDes;
        private bool _isExibirPes;
        private string _descricao;
        private string _valorIni;
        private string _valorFin;
        private string _valorDes;
        #endregion

        #region propriedades
        private AbstractCampoTipo Tipo
        {
            get => _tipo;
            set
            {
                SetField(ref _tipo, value);
                IsExibirBtn = value.IsIndiv() || value.IsInter();
                IsExibirIni = value.IsIndiv() || value.IsInter();
                IsExibirFin = value.IsInter();
                IsExibirDes = value.IsDescr();
                IsExibirPes = value.IsPesq();
            }
        }
        public bool IsExibirBtn { get => _isExibirBtn; set => SetField(ref _isExibirBtn, value); }
        public bool IsExibirIni { get => _isExibirIni; set => SetField(ref _isExibirIni, value); }
        public bool IsExibirFin { get => _isExibirFin; set => SetField(ref _isExibirFin, value); }
        public bool IsExibirDes { get => _isExibirDes; set => SetField(ref _isExibirDes, value); }
        public bool IsExibirPes { get => _isExibirPes; set => SetField(ref _isExibirPes, value); }
        public string Descricao
        {
            get => _descricao;
            set => SetField(ref _descricao, value);
        }
        public AbstractEditTipo EditTipo
        {
            get => _editTipo;
            set => SetField(ref _editTipo, value);
        }
        public string ValorIni { get => _valorIni; set => SetField(ref _valorIni, value); }
        public string ValorFin { get => _valorFin; set => SetField(ref _valorFin, value); }
        public string ValorDes { get => _valorDes; set => SetField(ref _valorDes, value); }
        #endregion

        #region comandos
        #endregion

        #region contrutores
        public AbstractCampoViewModel(AbstractCampoTipo tipo, string descricao = null, AbstractEditTipo? editTipo = null)
        {
            Tipo = tipo;

            if (descricao != null)
                Descricao = descricao;
            if (editTipo != null)
                EditTipo = editTipo.Value;
        }
        #endregion

        #region metodos
        #endregion
    }
}