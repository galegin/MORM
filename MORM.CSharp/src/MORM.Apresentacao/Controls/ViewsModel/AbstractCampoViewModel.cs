using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractCampoViewModel : AbstractViewModel
    {
        #region variaveis
        private AbstractCampoTipo _tipo;
        private AbstractEditTipo _editTipo;
        private bool _isExibirBtn;
        private bool _isExibirIni;
        private bool _isExibirFin;
        private bool _isExibirDes;
        private bool _isExibirPes;
        private string _descricao;
        private int _tamanho;
        private int _tamanhoBtn = 100;
        private int _tamanhoIni = 100;
        private int _tamanhoFin = 100;
        private int _tamanhoDes = 100;
        private int _precisao;
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
        public int Tamanho
        {
            get => _tamanho;
            set => SetField(ref _tamanho, value);
        }
        public int TamanhoBtn { get => _tamanhoBtn; set => SetField(ref _tamanhoBtn, value); }
        public int TamanhoIni { get => _tamanhoIni; set => SetField(ref _tamanhoIni, value); }
        public int TamanhoFin { get => _tamanhoFin; set => SetField(ref _tamanhoFin, value); }
        public int TamanhoDes { get => _tamanhoDes; set => SetField(ref _tamanhoDes, value); }
        public int Precisao
        {
            get => _precisao;
            set => SetField(ref _precisao, value);
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

        #region construtores
        public AbstractCampoViewModel(AbstractCampoTipo tipo, 
            string descricao = null, int tamanho = 0, int precisao = 0,
            AbstractEditTipo? editTipo = null)
        {
            Tipo = tipo;

            if (descricao != null)
                Descricao = descricao;
            if (tamanho >= 0)
                SetTamanho(tamanho);
            if (precisao >= 0)
                Precisao = precisao;
            if (editTipo != null)
                EditTipo = editTipo.Value;
        }

        private void SetTamanho(int tamanho)
        {
            Tamanho = tamanho;
            TamanhoIni = tamanho * 10;
            TamanhoFin = tamanho * 10;
            TamanhoDes = tamanho * 10;
        }
        #endregion
    }
}