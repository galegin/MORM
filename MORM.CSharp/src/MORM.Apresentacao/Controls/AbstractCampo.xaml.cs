using MORM.Apresentacao.Comps;
using MORM.Enums.Classes;
using System.Windows.Controls;
using System.Windows.Data;

namespace MORM.Apresentacao.Controls
{
    #region enun
    public enum AbstractCampoTipo
    {
        Individual,
        IndividualComDescricao,
        IndividualComPesquisa,
        IndividualComPesquisaEDescricao,
        Intervalo,
        IntervaloComDescricao,
        IntervaloComPesquisa,
        IntervaloComPesquisaEDescricao,
    }

    public static class AbstractCampoTipoExtensions
    {
        public static bool IsDescr(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.IndividualComDescricao,
                AbstractCampoTipo.IndividualComPesquisaEDescricao,
                AbstractCampoTipo.IntervaloComDescricao,
                AbstractCampoTipo.IntervaloComPesquisaEDescricao);
        }

        public static bool IsIndiv(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.Individual,
                AbstractCampoTipo.IndividualComDescricao,
                AbstractCampoTipo.IndividualComPesquisa,
                AbstractCampoTipo.IndividualComPesquisaEDescricao);
        }

        public static bool IsInter(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.Intervalo,
                AbstractCampoTipo.IntervaloComDescricao,
                AbstractCampoTipo.IntervaloComPesquisa,
                AbstractCampoTipo.IntervaloComPesquisaEDescricao);
        }

        public static bool IsPesq(this AbstractCampoTipo tipo)
        {
            return tipo.In(
                AbstractCampoTipo.IndividualComPesquisa,
                AbstractCampoTipo.IndividualComPesquisaEDescricao,
                AbstractCampoTipo.IntervaloComPesquisa,
                AbstractCampoTipo.IntervaloComPesquisaEDescricao);
        }
    }
#endregion

    public partial class AbstractCampo : AbstractUserControlNotify
    {
        #region construtores
        public AbstractCampo(AbstractCampoTipo tipo, string descricao = null, AbstractEditTipo? editTipo = null)
        {
            InitializeComponent();

            Tipo = tipo;

            if (descricao != null)
                Descricao = descricao;
            if (editTipo != null)
                EditTipo = editTipo.Value;

            DataContext = this;
        }
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
            set
            {
                SetField(ref _editTipo, value);
                EditIni.Tipo = value;
                EditFin.Tipo = value;
            }
        }
        public string ValorIni { get => _valorIni; set => SetField(ref _valorIni, value); }
        public string ValorFin { get => _valorFin; set => SetField(ref _valorFin, value); }
        public string ValorDes { get => _valorDes; set => SetField(ref _valorDes, value); }
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